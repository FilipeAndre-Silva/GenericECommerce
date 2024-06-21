using AutoMapper;
using GenericEcommerce.Application.Dto.Product.Response;
using GenericEcommerce.Domain.Entities;

namespace GenericEcommerce.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>().ReverseMap();
    }
}