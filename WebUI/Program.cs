using Application;
using Infrastructure;
namespace WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        var configuration = builder.Configuration;

        builder.Services.AddInfrastructureServices(configuration);
        builder.Services.AddApplicationServices(configuration);
        builder.Services.AddWebUIServices(configuration);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Category}/{action=Index}/{id?}");
        app.Run();
    }
}