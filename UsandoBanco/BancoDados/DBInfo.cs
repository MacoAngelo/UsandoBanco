using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UsandoBanco.BancoDados
{
    internal class DBInfo
    {
        // Utilizamos o @ para evitar o barra invertida. Por exemplo: \n.
        public const string DBConnection = @"Data Source=BUE0102D001\SQLEXPRESS;Initial Catalog=IntegraDB;User ID=sa;Password=Senac@2023";

        public static bool TestDBConnection()
        {
            var result = false;
            using (var conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(ID) FROM PRODUTOS";

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine($"O comando foi executado e retornou {reader.GetInt32(0)} registros em Produtos!");
                }
                //conn.Close();
            }

            return result;
        }
    }
}