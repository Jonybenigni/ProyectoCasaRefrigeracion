using AutoMapper;
using Refrigeracion.Application.DTOs.ProductSupplier;
using Refrigeracion.Application.DTOs.SupplierPayment;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class ProductSupplierMappingProfile : Profile
    {
        public ProductSupplierMappingProfile()
        {
            CreateMap<ProductSupplierRequestDto, ProductSupplier>();

            CreateMap<ProductSupplier, ProductSupplierResponseDto>()
                .ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name)
                )
                .ForMember(
                    dest => dest.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier.Name)
                );
        }
    }
}
