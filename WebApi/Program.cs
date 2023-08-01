using Application;
using Infrastructure;
namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var configuration = builder.Configuration;

            builder.Services.AddInfrastructureServices(configuration);
            builder.Services.AddApplicationServices(configuration);
            builder.Services.AddWebUIServices(configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseGlobalExceptionMiddleware();


            app.MapControllers();
            app.Run();
        }
    }
}