using GenericEcommerce.Domain.Entities;

namespace GenericEcommerce.Domain.Interfaces.Repositories;
public interface IProductRepository
{
    Task<List<Product>> GetAllProductsAsync();
}