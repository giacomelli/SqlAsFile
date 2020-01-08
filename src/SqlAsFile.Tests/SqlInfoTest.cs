using NUnit.Framework;

namespace SqlAsFile.Tests
{
    public class SqlInfoTest
    {        
        [Test]
        public void Operator_String_SqlInfo()
        {
            SqlInfo actual = "SELECT * FROM TEST";

            Assert.AreEqual("", actual.Cte);
            Assert.AreEqual("SELECT * FROM TEST", actual.Content);
        }

        [Test]
        public void Operator_SqlInfo_String()
        {
            SqlInfo sqlInfo = "SELECT * FROM TEST";
            string actual = sqlInfo;

            Assert.AreEqual("SELECT * FROM TEST", actual);
        }
    }
}