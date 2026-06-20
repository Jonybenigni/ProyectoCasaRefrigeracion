using AutoMapper;
using Refrigeracion.Application.DTOs.PendingJob;
using Refrigeracion.Application.DTOs.SupplierPayment;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class SupplierPaymentMappingProfile:Profile
    {
        public SupplierPaymentMappingProfile()
        {
            CreateMap<SupplierPaymentRequestDto, SupplierPayment>();

            CreateMap<SupplierPayment, SupplierPaymentResponseDto>()
                 .ForMember(
                 dest => dest.SupplierName,
                 opt => opt.MapFrom(src => src.Supplier.Name)
            );
        }



    }
}
