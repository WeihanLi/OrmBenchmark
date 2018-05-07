using System.Collections.Generic;
using System.Linq;
using OrmBenchmark.Core;

namespace OrmBenchmark.EntityFramework
{
    public class EntityFrameworkExecuter : IOrmExecuter
    {
        private OrmBenchmarkContext ctx;

        public string Name => "Entity Framework";

        public void Init(string connectionString)
        {
            ctx = new OrmBenchmarkContext();
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
