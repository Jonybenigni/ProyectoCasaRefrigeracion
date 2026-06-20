using AutoMapper;
using Refrigeracion.Application.DTOs.PendingJob;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class PendingJobMappingProfile:Profile
    {
        public PendingJobMappingProfile()
        {
            CreateMap<PendingJobRequestDto, PendingJob>();

            CreateMap<PendingJob, PendingJobResponseDto>()
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.Name)
                );
        }


    }
}
