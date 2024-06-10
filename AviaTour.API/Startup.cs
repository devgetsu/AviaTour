using AviaTour.API.Interfaces;
using AviaTour.API.Middlewares;
using AviaTour.Application;
using AviaTour.Infrastructure;
using Newtonsoft.Json;

namespace AviaTour.API
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services, ILoggingBuilder Logging)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); ;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddInfrastructureDependencyInjection(configRoot);
            services.AddApplicationDependencyInjection();
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors(options =>
            {
                options.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
