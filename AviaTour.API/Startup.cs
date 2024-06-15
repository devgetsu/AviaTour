using AviaTour.API.Interfaces;
using AviaTour.API.Middlewares;
using AviaTour.Application;
using AviaTour.Domain.Entities.Auth;
using AviaTour.Infrastructure;
using AviaTour.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            services.AddApplicationDependencyInjection();
            services.AddInfrastructureDependencyInjection(configRoot);

            services.AddIdentity<User, IdentityRole<long>>()
                .AddEntityFrameworkStores<AviaTourDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<Random>();
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

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<long>>>();

                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                        roleManager.CreateAsync(new IdentityRole<long>(role)).Wait();
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string email = "admin01@admin.com";
                string password = "Admin01!";

                if (userManager.FindByEmailAsync(email).Result == null)
                {
                    var user = new User()
                    {
                        UserName = "Admin",
                        Name = "Admin",
                        Surname = "Admin",
                        Email = email,
                        PhotoUrl = "https://ih1.redbubble.net/image.2955130987.9629/raf,360x360,075,t,fafafa:ca443f4786.jpg",
                        Password = password,
                        PhoneNumber = "+998777777777",
                        Role = "Admin"
                    };

                    userManager.CreateAsync(user, password).Wait();

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            app.Run();
        }
    }
}
