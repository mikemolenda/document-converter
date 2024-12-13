using DocumentConverter.App.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentConverter.App.Configuration;

public static class ServiceExtensions
{
    // Add services to the container.
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IDocumentFileService, DocumentFileService>();
        services.AddScoped<IDocumentProcessingService, DocumentProcessingService>();
        return services;
    }
}