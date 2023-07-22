using EF.PostgreSql;
using Newtonsoft.Json;
using Services;

namespace API
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.EF_Setup(configuration.GetConnectionString("DefaultConnection"));
            services.ServiceSetup();
        }
    }
}
