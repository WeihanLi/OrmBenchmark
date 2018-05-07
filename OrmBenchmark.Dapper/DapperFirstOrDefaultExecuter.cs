using Dapper;
using OrmBenchmark.Core;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OrmBenchmark.Dapper
{
    public class DapperFirstOrDefaultExecuter : IOrmExecuter
    {
        private SqlConnection conn;

        public string Name => "Dapper Query (First Or Default)";

        public void Init(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public IPost GetItemAsObject(int id)
        {
            return conn.QueryFirstOrDefault<Post>("select * from Posts where Id=@Id", new { Id = id });
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            return null;
        }

        public void Finish()
        {
            conn.Close();
        }
    }
}