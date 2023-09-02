using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using EF.PostgreSql;

namespace Setup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Port=5432;Database=CMS_DB;User ID=postgres;Password='admin@123'";

            var contextFactory = new DbContextFactory<ApiDbContext>(connectionString);
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
    }
}