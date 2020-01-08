using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

namespace SqlAsFile
{
    /// <summary>
    /// Leitor de recursos utilizado nos comandos SQL.
    /// </summary>
    public static class SqlResourceReader
    {
        private static ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();
   
        /// <summary>
        /// Realiza a leitura do comando no recurso informado.
        /// </summary>
        /// <remarks>
        /// O arquivo SQL deve estar na pasta Sql do projeto SqlAsFile.
        /// </remarks>
        /// <param name="file">O arquivo SQL.</param>
        /// <returns>O comando.</returns>
        public static string Read(FileSqlInfo file)
        {
            var assembly = file.Assembly;
            var key = file.RelativeFilePath.Replace("/", ".");

            if (!_cache.ContainsKey(key))
            {
                string resourceName;

                try
                {
                    resourceName = assembly.GetManifestResourceNames().SingleOrDefault(x => x.EndsWith(key));
                }
                catch(InvalidOperationException ex)
                {
                    throw new InvalidOperationException($"Existe mais de um arquivo '{file.RelativeFilePath}' no assembly '{assembly.GetName().Name}'. Utilize o nome da pasta ao instanciar o SqlFile para especificar o arquivo desejado.", ex);
                }

                if (resourceName == null)
                    throw new InvalidOperationException($"Não foi possível localizar um arquivo SQL no caminho '{file.RelativeFilePath}' ({key}).");                

                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream))
                {
                    _cache.TryAdd(key, reader.ReadToEnd());
                }
            }

            return _cache[key];
        }     
    }
}
