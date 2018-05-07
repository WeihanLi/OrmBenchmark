using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using OrmBenchmark.Core;
using WeihanLi.Extensions;

namespace OrmBenchmartk.WeihanLi.Common
{
    public class WeihanLiCommonExecuter : IOrmExecuter
    {
        public string Name => "WeihanLi.Common";
        private SqlConnection conn;

        public void Init(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public IPost GetItemAsObject(int id)
        {
            return conn.Fetch<Post>("select * from Posts where Id = @Id", new { Id = id });
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            return conn.Select<Post>("select * from Posts").ToArray<IPost>();
        }

        public void Finish()
        {
            conn.Close();
        }
    }
}
