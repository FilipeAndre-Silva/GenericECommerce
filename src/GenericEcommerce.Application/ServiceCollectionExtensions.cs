using Microsoft.Extensions.DependencyInjection;
using GenericEcommerce.Infra;
using GenericEcommerce.Domain;
using GenericEcommerce.Application.Interfaces;
using GenericEcommerce.Application.Services;

namespace GenericEcommerce.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddInfraDependency();
        services.AddDomainServiceDependency();

        services.AddScoped<IProductApplicationService, ProductApplicationService>();
    }
}