using Sample.Data.SampleNamespace1;

using SqlAsFile;
using System;

namespace Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteSql("SampleSql1", Sql.SampleSql1);
            WriteSql("SampleSql2", Data.SampleNamespace1.SampleSubNamespace1.Sql.SampleSql2);
            WriteSql("SampleSql3", Data.SampleNamespace2.Sql.SampleSql3);

            Console.ReadKey();
        }

        static void WriteSql(string name, SqlInfo content)
        {
            Console.WriteLine();
            Console.WriteLine("".PadRight(80, '-'));
            Console.WriteLine($"{name}.sql content:".ToUpperInvariant());
            Console.WriteLine(content);
        }
    }
}
