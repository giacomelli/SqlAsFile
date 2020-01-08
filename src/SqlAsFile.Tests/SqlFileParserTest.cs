using NUnit.Framework;

namespace SqlAsFile.Tests
{
    public class SqlFileParserTest
    {        
        [Test]
        [TestCase("Stubs/SampleNamespace1/SampleSql1.sql", "SAMPLESQL1 - CTE", "SAMPLESQL1 - CONTENT")]
        [TestCase("Stubs/SampleNamespace1/SampleSubNamespace1/SampleSql2.sql", "SAMPLESQL2 - CTE", "SAMPLESQL2 - CONTENT")]
        [TestCase("Stubs/SampleNamespace2/SampleSql3.sql", "SAMPLESQL3 - CTE", "SAMPLESQL3 - CONTENT")]
        public void Parse_FileSqlInfo_CteAndContent(
            string relativeFilePath, 
            string cte, 
            string content)
        {
            var actual = SqlFileParser.Parse(new FileSqlInfo(relativeFilePath));
            AssertHelper.Cte(cte, actual.Item1);
            AssertHelper.Content(content, actual.Item2);
        }
    }
}