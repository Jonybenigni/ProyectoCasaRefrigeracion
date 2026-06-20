using AutoMapper;
using Refrigeracion.Application.DTOs.Supplier;
using Refrigeracion.Application.DTOs.TaskItem;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Mapping
{
    public class TaskItemMappingProfile:Profile
    {
        public TaskItemMappingProfile()
        {
            CreateMap<TaskItemRequestDto, TaskItem>();
            CreateMap<TaskItem, TaskItemResponseDto>();
        }





    }
}
