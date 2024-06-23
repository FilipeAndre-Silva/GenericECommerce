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

    public async Task<List<Product>> GetAllAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }
        if (pageSize < 1)
        {
            pageSize = 10;
        }

        return await _context.Products
        .Skip((pageNumber - 1) * pageSize) // Pula os registros das páginas anteriores
        .Take(pageSize) // Toma a quantidade de registros especificada
        .ToListAsync();
    }
    
    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async void CreatetAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async void DeleteAsybc(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}