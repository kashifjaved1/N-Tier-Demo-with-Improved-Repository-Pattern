using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Repositories.Entities;

namespace EF.PostgreSql
{
    public class ApiDbContext : DbContext, ICMSRepository
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        //private readonly IConfiguration _configuration;

        //public ApiDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        // below method syntax is equivalent to services.AddDbContext<ApiDbContext>(options => options.UseNpgsql("connectionString"));
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        //}

        public DbSet<Classroom> Classrooms { get; private set; }
        public DbSet<Student> Students { get; private set; }
    }
}
