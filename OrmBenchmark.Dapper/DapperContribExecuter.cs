using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using OrmBenchmark.Core;

namespace OrmBenchmark.Dapper
{
    public class DapperContribExecuter : IOrmExecuter
    {
        private SqlConnection conn;

        public string Name => "Dapper Contrib";

        public void Init(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public IPost GetItemAsObject(int id)
        {
            return conn.Get<Post>(id);
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            return conn.GetAll<Post>().ToList<IPost>();
        }

        public void Finish()
        {
            conn.Close();
        }
    }
}
