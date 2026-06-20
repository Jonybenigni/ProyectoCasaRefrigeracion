using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.TaskItem;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        private readonly IMapper _mapper;

        public TaskItemsController(ITaskItemService taskItemService, IMapper mapper)
        {
            _taskItemService = taskItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskItems = await _taskItemService.GetAll();
            var result = _mapper.Map<List<TaskItemResponseDto>>(taskItems);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskItem = await _taskItemService.GetById(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<TaskItemResponseDto>(taskItem);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskItemRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var taskItem = _mapper.Map<TaskItem>(request);
            await _taskItemService.Add(taskItem);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItemRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existing = await _taskItemService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            _mapper.Map(request, existing);
            await _taskItemService.Update(existing);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _taskItemService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _taskItemService.Delete(id);
            return Ok();
        }
    }
}
