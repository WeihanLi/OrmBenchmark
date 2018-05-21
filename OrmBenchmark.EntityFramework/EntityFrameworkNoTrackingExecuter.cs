using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrmBenchmark.Core;
using OrmBenchmark.EntityFramework;

namespace OrmBenchmark.EntityFrameworkCore
{
    public class EntityFrameworkCoreNoTrackingExecuter : IOrmExecuter
    {
        private OrmBenchmarkContext ctx;

        public string Name => "Entity Framework Core(No Tracking)";

        public void Init(string connectionString)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(connectionString);
            ctx = new OrmBenchmarkContext(dbContextBuilder.Options);
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
