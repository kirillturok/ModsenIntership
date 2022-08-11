﻿using Microsoft.EntityFrameworkCore;
using Repository;

namespace CqrsExample.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(opts
                => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("CqrsExample")));

    public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<ProductRepository>();
}
