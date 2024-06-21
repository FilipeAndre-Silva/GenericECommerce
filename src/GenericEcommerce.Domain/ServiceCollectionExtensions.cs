using GenericEcommerce.Domain.Interfaces;
using GenericEcommerce.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GenericEcommerce.Domain;

public static class ServiceCollectionExtensions
{
    public static void AddDomainServiceDependency(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}