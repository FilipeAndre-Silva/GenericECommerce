using AutoMapper;
using GenericEcommerce.Application.Dto.Product.Response;
using GenericEcommerce.Application.Interfaces;
using GenericEcommerce.Domain.Interfaces;

namespace GenericEcommerce.Application.Services;

public class ProductApplicationService : IProductApplicationService
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;
    public ProductApplicationService(IMapper mapper, IProductService productService)
    {
        _mapper = mapper;
        _productService = productService;
    }

    public async Task<List<ProductResponse>> GetAllProductsAsync(int pageNumber, int pageSize)
    {
        var result = await _productService.GetAllProductsAsync(pageNumber, pageSize);
        return  _mapper.Map<List<ProductResponse>>(result);
    }
}