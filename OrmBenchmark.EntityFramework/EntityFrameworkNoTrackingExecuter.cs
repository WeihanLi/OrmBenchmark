using System.Collections.Generic;
using System.Linq;
using OrmBenchmark.Core;

namespace OrmBenchmark.EntityFramework
{
    public class EntityFrameworkNoTrackingExecuter : IOrmExecuter
    {
        private OrmBenchmarkContext ctx;

        public string Name => "Entity Framework(No Tracking)";

        public void Init(string connectionString)
        {
            ctx = new OrmBenchmarkContext();
        }

        public IPost GetItemAsObject(int id)
        {
            return ctx.Posts.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            return ctx.Posts.AsNoTracking().ToArray<IPost>();
        }

        public void Finish()
        {
        }
    }
}
