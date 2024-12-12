using DocumentConverter.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentConverter.App.Configuration;

public static class DbExtensions
{
    // Add the database context to the container.
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DocumentConverterAppContext>(options => {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
            
        return services;
    }
}