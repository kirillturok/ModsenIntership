using Microsoft.EntityFrameworkCore;
using Products.Repository;
using Products.Repository.Context;

namespace Products.WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
            => services.AddDbContext<ProductsContext>(opts
                => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("Products.WebApi")));

    public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<ProductsRepository>();
}
