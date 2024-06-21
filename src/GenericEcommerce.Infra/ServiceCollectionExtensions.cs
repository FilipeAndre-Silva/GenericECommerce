using GenericEcommerce.Domain.Interfaces.Repositories;
using GenericEcommerce.Infra.Data;
using GenericEcommerce.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericEcommerce.Infra;

public static class ServiceCollectionExtensions
{
    public static void AddInfraDependency(this IServiceCollection services)
    {
        services.AddDbContext<GenericEcommerceDbContext>(options => options.UseSqlite("Data Source=GenericEcommerceDb.db"));
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}