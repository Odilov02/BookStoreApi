using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using WebApi.Comman.Services;

namespace WebApi
{
    public static class ConfigService
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {
            services.AddMediatR(src => src.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddIdentity<User, IdentityRole>()
                    .AddUserManager<UserManager<User>>()
                    .AddRoleManager<RoleManager<IdentityRole>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddSignInManager();

            services.AddHttpContextAccessor();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserManigerService<User>, UserManagerService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
    }
}
 