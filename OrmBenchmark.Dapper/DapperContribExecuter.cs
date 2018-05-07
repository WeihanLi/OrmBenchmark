using Dapper.Contrib.Extensions;
using OrmBenchmark.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace OrmBenchmark.Dapper
{
    public class DapperContribExecuter : IOrmExecuter
    {
        private SqlConnection conn;

        public string Name => "Dapper Contrib";

        public void Init(string connectionStrong)
        {
            conn = new SqlConnection(connectionStrong);
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