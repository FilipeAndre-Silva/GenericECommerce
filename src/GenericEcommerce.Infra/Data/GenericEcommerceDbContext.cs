using GenericEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Infra.Data;

public class GenericEcommerceDbContext : DbContext
{
    public GenericEcommerceDbContext(DbContextOptions<GenericEcommerceDbContext> options) 
    : base(options)
    { }

    public DbSet<Product> Products { get; set; }
}