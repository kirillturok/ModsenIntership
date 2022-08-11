using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Contracts;

namespace _3LayerExample.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(opts
                => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("3LayerExample")));

    public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
}
