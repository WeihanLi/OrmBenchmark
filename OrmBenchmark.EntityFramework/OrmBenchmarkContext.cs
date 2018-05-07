using System.Data.Entity;
using OrmBenchmark.Core;

namespace OrmBenchmark.EntityFramework
{
    internal class OrmBenchmarkContext : DbContext
    {
        public OrmBenchmarkContext()
            : base("name=sqlServerLocal")
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
