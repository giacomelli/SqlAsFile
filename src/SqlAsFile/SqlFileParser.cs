using System;
using System.Text.RegularExpressions;

namespace SqlAsFile
{
    public static class SqlFileParser
    {
        private static Regex _removeTestArgsRegex = new Regex("--<test-args>.+--</test-args>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private static Regex _selectCteRegex = new Regex("--<cte>.+--</cte>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Tuple<string, string> Parse(FileSqlInfo file)
        {
            var content = SqlResourceReader.Read(file);
            return new Tuple<string, string>(
                ParseCte(content), 
                ParseComand(content));
        }

        private static string ParseComand(string sql)
        {
            var sqlWithoutArgs = _removeTestArgsRegex.Replace(sql, string.Empty);
            var sqlWithoutCte = _selectCteRegex.Replace(sqlWithoutArgs, string.Empty);
            return sqlWithoutCte;
        }

        private static string ParseCte(string sql)
        {
            var cte = string.Empty;
            var match = _selectCteRegex.Match(sql);
            if (match != null)
            {
                cte = match.Value;
            }

            return cte;
        }
    }
}
