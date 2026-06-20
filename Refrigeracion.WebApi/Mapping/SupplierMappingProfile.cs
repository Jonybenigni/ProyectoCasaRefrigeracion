using AutoMapper;
using Refrigeracion.Application.DTOs.Supplier;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class SupplierMappingProfile:Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<SupplierRequestDto, Supplier>();
            CreateMap<Supplier, SupplierResponseDto>();
        }



    }
}
