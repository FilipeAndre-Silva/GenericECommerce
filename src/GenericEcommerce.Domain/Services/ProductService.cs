using GenericEcommerce.Domain.Entities;
using GenericEcommerce.Domain.Interfaces;
using GenericEcommerce.Domain.Interfaces.Repositories;

namespace GenericEcommerce.Domain.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAllProductsAsync();
    }
}