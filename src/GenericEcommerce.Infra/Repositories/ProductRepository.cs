using GenericEcommerce.Domain.Entities;
using GenericEcommerce.Domain.Interfaces.Repositories;
using GenericEcommerce.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly GenericEcommerceDbContext _context;

    public ProductRepository(GenericEcommerceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}