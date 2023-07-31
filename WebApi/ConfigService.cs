using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using WebApi.Comman.Interfaces;
using WebApi.Comman.Services;

namespace WebApi
{
    public static class ConfigService
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddSignInManager();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }
}
