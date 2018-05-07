using OrmBenchmark.Core;
using System.Data.Entity;

namespace OrmBenchmark.EntityFramework
{
    internal class OrmBenchmarkContext : DbContext
    {
        public OrmBenchmarkContext(string connectionStrong)
            : base("name=sqlServerLocal")
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}