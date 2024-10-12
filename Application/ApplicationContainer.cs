

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationContainer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(ApplicationContainer)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationContainer).Assembly));

            return services;
        }
    }
}
