using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Setup
{
    public class DbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private readonly string connectionString;

        public DbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            // Configure the database connection, provider, and other options here
            optionsBuilder.UseNpgsql(connectionString);

            return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
        }
    }
}
