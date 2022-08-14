using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products.Repository;
using Products.Repository.Context;

namespace Products.WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
            => services.AddDbContext<OrdersContext>(opts
                => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("Orders.WebApi")));

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("Events", new OpenApiInfo
            {
                Title = "Events",
                Version = "Events"
            });
            s.SwaggerDoc("Authentication", new OpenApiInfo
            {
                Title = "Authentication",
                Version = "Authentication"
            });
            s.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
        });
    }
}
