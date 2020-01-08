using NUnit.Framework;
using System;

namespace SqlAsFile.Tests
{
    public class SqlResourceReaderTest
    {        
        [Test]
        [TestCase("Folder/File.sql", null, null, "Could not find a file on location 'Folder/File.sql'.")]
        [TestCase("SampleSql1.sql", null, null, "There is more than a file 'SampleSql1.sql' on assembly 'SqlAsFile.Tests'. Use the folder path when instancianting a SQL file to specify the right file.")]
        [TestCase("Stubs/SampleNamespace1/SampleSql1.sql", "SAMPLESQL1 - CTE", "SAMPLESQL1 - CONTENT", null)]
        [TestCase("Stubs/SampleNamespace1/SampleSubNamespace1/SampleSql2.sql", "SAMPLESQL2 - CTE", "SAMPLESQL2 - CONTENT", null)]
        [TestCase("Stubs/SampleNamespace2/SampleSql3.sql", "SAMPLESQL3 - CTE", "SAMPLESQL3 - CONTENT", null)]
        public void Read_FileSqlInfo_FileContent(
            string relativeFilePath,             
            string cte,
            string content,
            string exception)
        {
            try
            {
                var actual = SqlResourceReader.Read(new FileSqlInfo(relativeFilePath));
                Assert.AreEqual($"--<test-args>\r\nDECLARE @test INT = 2;\r\n--</test-args>\r\n\r\n--<cte>\r\n{cte}\r\n--</cte>\r\n\r\n{content}", actual);
                Assert.IsNull(exception);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(exception, ex.Message);
            }
        }
    }
}