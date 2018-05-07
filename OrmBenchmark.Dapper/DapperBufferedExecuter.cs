using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using OrmBenchmark.Core;

namespace OrmBenchmark.Dapper
{
    public class DapperBufferedExecuter : IOrmExecuter
    {
        private SqlConnection conn;

        public string Name => "Dapper Query (Buffered)";

        public void Init(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public IPost GetItemAsObject(int id)
        {
            return conn.Query<Post>("select * from Posts where Id=@Id", new { Id = id }, buffered: true).First();
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            return conn.Query<Post>("select * from Posts", buffered: true).ToArray<IPost>();
        }

        public void Finish()
        {
            conn.Close();
        }
    }
}
