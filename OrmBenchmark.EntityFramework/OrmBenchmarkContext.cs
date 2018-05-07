using Microsoft.EntityFrameworkCore;
using OrmBenchmark.Core;

namespace OrmBenchmark.EntityFramework
{
    public class OrmBenchmarkContext : DbContext
    {
        public OrmBenchmarkContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(_ => _.Id);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
