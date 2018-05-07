using OrmBenchmark.Core;
using System.Collections.Generic;
using System.Linq;

namespace OrmBenchmark.EntityFramework
{
    public class EntityFrameworkExecuter : IOrmExecuter
    {
        private OrmBenchmarkContext ctx;

        public string Name => "Entity Framework";

        public void Init(string connectionStrong)
        {
            ctx = new OrmBenchmarkContext(connectionStrong);
        }

        public IPost GetItemAsObject(int id)
        {
            return ctx.Posts.FirstOrDefault(p => p.Id == id);
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            return ctx.Posts.ToList<IPost>();
        }

        public void Finish()
        {
        }
    }
}