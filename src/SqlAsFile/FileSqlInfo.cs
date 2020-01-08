
using System.Reflection;

namespace SqlAsFile
{
    /// <summary>
    /// Provê informações sobre um comando SQL definido em arquivo.
    /// </summary>
    public class FileSqlInfo : SqlInfo
    {
        /// <summary>
        /// Cria uma nova instância de FileSqlInfo.
        /// </summary>
        /// <param name="relativeFilePath">O caminho relativo arquivo .sql dentro do projeto.</param>
        public FileSqlInfo(string relativeFilePath)
        {
            RelativeFilePath = relativeFilePath;
            Assembly = Assembly.GetCallingAssembly();

            var sql = SqlFileParser.Parse(this);
            Cte = sql.Item1;
            Content = sql.Item2;
        }

        public string RelativeFilePath { get; private set; }        

        public Assembly Assembly { get; private set; }
    }
}
