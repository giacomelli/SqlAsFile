using NUnit.Framework;

namespace SqlAsFile.Tests
{
    public static class AssertHelper
    {
        public static void Full(string expectedCte, string expectedContent, string actual)
        {
            Assert.AreEqual(
                $"--<test-args>DECLARE @test INT = 2;--</test-args>--<cte>{expectedCte}--</cte>{expectedContent}".RemoveNewLines(),
                actual.RemoveNewLines());
        }

        public static void Cte(string expected, string actual)
        {
            Assert.AreEqual($"--<cte>{expected}--</cte>".RemoveNewLines(), actual.RemoveNewLines());
        }

        public static void Content(string expected, string actual)
        {
            Assert.AreEqual(expected.RemoveNewLines(), actual.RemoveNewLines());
        }

        static string RemoveNewLines(this string value)
        {
            return value.Replace("\r", "")
                        .Replace("\n", "");
        }
    }
}
