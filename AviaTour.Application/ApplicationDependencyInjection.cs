using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AviaTour.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
