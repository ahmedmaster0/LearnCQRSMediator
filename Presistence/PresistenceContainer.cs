using Application.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Repositories;


namespace Presistence
{
    public static  class PresistenceContainer
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IBaseAyncRepository<>),typeof(BaseAsyncRepository<>));
            services.AddScoped(typeof(IPostAsyncRepository),typeof(PostAsyncRepository));
            services.AddScoped(typeof(ICategoryAsyncRepository),typeof(CategoryAsyncRepository));

            return services;
        }
    }
}
