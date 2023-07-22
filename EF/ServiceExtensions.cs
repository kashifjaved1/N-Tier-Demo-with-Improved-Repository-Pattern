using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.PostgreSql
{
    public static class ServiceExtensions
    {
        public static void EF_Setup(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}