using System;

namespace SqlAsFile
{
    /// <summary>
    /// Provê informações sobre um comando SQL.
    /// </summary>
    public class SqlInfo
    {
        /// <summary>
        /// Obtém o conteúdo principal do comando SQL (sem CTE).
        /// </summary>
        public string Content { get; protected set; }

        /// <summary>
        /// Obtém o conteúdo da CTE.
        /// </summary>
        /// <remarks>
        /// CTEs são definidas entre as tags --<cte> --</cte> no arquivo .sql.
        /// </remarks>
        public string Cte { get; protected set;}

        /// <summary>
        /// Retornar o comando completo.
        /// </summary>
        /// <returns>O comando SQL completo: cte + content.</returns>
        public override string ToString()
        {
           return Cte + Content;
        }

        public static implicit operator String(SqlInfo value)
        {
            return value.ToString();
        }

        public static implicit operator SqlInfo(string content)
        {
            return new SqlInfo
            {
                Content = content,
                Cte = String.Empty
            };
        }
    }
}