using AutoMapper;
using Refrigeracion.Application.DTOs.Customer;
using Refrigeracion.Application.DTOs.Supplier;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerRequestDto, Customer>();
            CreateMap<Customer, CustomerResponseDto>();
        }


    }
}
