using NUnit.Framework;
using System;

namespace SqlAsFile.Tests
{
    public class FileSqlInfoTest
    {        
        [Test]
        [TestCase("Stubs/SampleNamespace1/SampleSql1.sql", "SAMPLESQL1 - CTE", "SAMPLESQL1 - CONTENT")]
        [TestCase("Stubs/SampleNamespace1/SampleSubNamespace1/SampleSql2.sql", "SAMPLESQL2 - CTE", "SAMPLESQL2 - CONTENT")]
        [TestCase("Stubs/SampleNamespace2/SampleSql3.sql", "SAMPLESQL3 - CTE", "SAMPLESQL3 - CONTENT")]
        public void Constructor_RelativeFilePath_Properties(
            string relativeFilePath, 
            string cte, 
            string content)
        {
            var actual = new FileSqlInfo(relativeFilePath);
            Assert.AreEqual(GetType().Assembly, actual.Assembly);
            Assert.AreEqual($"--<cte>{Environment.NewLine}{cte}{Environment.NewLine}--</cte>", actual.Cte);
            Assert.AreEqual($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}{content}", actual.Content);            
        }
    }
}