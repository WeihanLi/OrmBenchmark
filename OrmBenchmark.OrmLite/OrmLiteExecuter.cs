using System.Collections.Generic;
using System.Data;
using System.Linq;
using OrmBenchmark.Core;
using ServiceStack.OrmLite;

namespace OrmBenchmark.OrmLite
{
    public class OrmLiteExecuter : IOrmExecuter
    {
        private IDbConnection conn;
        private OrmLiteConnectionFactory dbFactory;

        public string Name => "Orm Lite";

        public void Init(string connectionString)
        {
            dbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
            conn = dbFactory.Open();
        }

        public IPost GetItemAsObject(int id)
        {
            return conn.Single<Post>("select * from Posts where Id=@Id", new { Id = id });
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
