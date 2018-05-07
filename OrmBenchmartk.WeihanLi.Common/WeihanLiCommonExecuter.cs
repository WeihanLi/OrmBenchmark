using OrmBenchmark.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WeihanLi.Extensions;

namespace OrmBenchmartk.WeihanLi.Common
{
    public class WeihanLiCommonExecuter : IOrmExecuter
    {
        public string Name => "WeihanLi.Common";
        private SqlConnection conn;

        public void Init(string connectionStrong)
        {
            conn = new SqlConnection(connectionStrong);
            conn.Open();
        }

        public IPost GetItemAsObject(int Id)
        {
            return conn.Fetch<Post>("select * from Posts where Id = @Id", new { Id });
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