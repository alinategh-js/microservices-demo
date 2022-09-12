using Catalog.API.DAL;
using Catalog.API.Repositories;
using Catalog.API.DAL.Interfaces;
using Catalog.API.Repositories.Interfaces;

namespace Catalog.API.Utils
{
    public static class ServicesInjector
    {
        public static IServiceCollection AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICatalogContext, CatalogContext>();

            return services;
        }

        public static IServiceCollection AddTransient(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddSingleton(this IServiceCollection services)
        {
            return services;
        }
    }
}
