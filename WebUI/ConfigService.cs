using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using WebUI.Comman.Interfaces;
using WebUI.Comman.Services;

namespace WebUI;

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
