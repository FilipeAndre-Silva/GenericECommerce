using GenericEcommerce.Application.Dto.Product.Response;

namespace GenericEcommerce.Application.Interfaces;

public interface IProductApplicationService
{
    Task<List<ProductResponse>> GetAllProductsAsync(int pageNumber, int pageSize);
}