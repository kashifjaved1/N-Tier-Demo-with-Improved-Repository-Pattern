using EF.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Contracts;
using Services.Implementation;

namespace Services
{
    public static class ServiceExtensions
    {
        public static void ServiceSetup(this IServiceCollection services)
        {
            // below repositories and services should be register at one place otherwise it'll do issues at code "x.GetRequiredService<ApiDbContext>()". 
            services.AddScoped<IClassroomRepository>(x => x.GetRequiredService<ApiDbContext>());
            services.AddScoped<IStudentRepository>(x => x.GetRequiredService<ApiDbContext>());

            services.AddScoped<ClassroomService>();
            services.AddScoped<StudentService>();
        }
    }
}