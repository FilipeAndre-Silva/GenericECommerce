using GenericEcommerce.Domain.Entities;

namespace GenericEcommerce.Domain.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync(int pageNumber, int pageSize);
}