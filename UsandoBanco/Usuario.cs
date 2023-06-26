using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoBanco.BancoDados;
using UsandoBanco.Criptografias;

namespace UsandoBanco
{
    internal class Usuario
    {
        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }

        public Usuario(string nickname)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ID, NICKNAME, PASSWORD, ISACTIVE FROM USERS WHERE NICKNAME = @NICKNAME";
                cmd.Parameters.AddWithValue("@NICKNAME", nickname);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        Nickname = reader.GetString(1);
                        Password = reader.GetString(2);
                        IsActive = reader.GetString(3) == "X" ? true : false;
                    }
                }
            }
        }

        public Usuario(string nickname, string password, bool isActive)
        {
            Nickname = nickname;
            Password = password;
            IsActive = isActive;
        }

        public void Save()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO USERS (NICKNAME, PASSWORD, ISACTIVE) VALUES (@NICKNAME, @PASSWORD, @ISACTIVE)";
                cmd.Parameters.AddWithValue("@NICKNAME", Nickname);
                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(Password, HashType.MD5).ToUpper());
                cmd.Parameters.AddWithValue("@ISACTIVE", IsActive ? "X" : ".");

                cmd.ExecuteNonQuery();
            }
        }
    }
}
