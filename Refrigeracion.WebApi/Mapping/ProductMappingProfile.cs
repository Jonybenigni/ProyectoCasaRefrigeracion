using AutoMapper;
using Refrigeracion.Application.DTOs.Product;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
