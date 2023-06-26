using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoBanco.Interfaces;

namespace UsandoBanco.BancoDados
{
    internal abstract class DataBaseRecordBase : IDataBaseRecord
    {
        public abstract string TableName { get; }

        public abstract int Id { get; }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = $"DELETE FROM {TableName.ToUpper()} WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
