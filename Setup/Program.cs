using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using EF.PostgreSql;

namespace Setup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contextFactory = new DbContextFactory<ApiDbContext>();
            using (var dbContext = contextFactory.CreateDbContext(null))
            {
                try
                {
                    // Apply any pending migrations to the database
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.Migrate();
                    Console.WriteLine("Migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error applying migrations: " + ex.Message);
                }
            }
        }

        private class DbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
        {
            public TContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TContext>();
                // Configure the database connection, provider, and other options here
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=CMS_DB;User ID=postgres;Password='admin@123'");

                return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
            }
        }
    }
}