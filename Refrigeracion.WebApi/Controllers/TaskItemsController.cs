using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController:ControllerBase
    {

        private readonly ITaskItemService _taskItemService;

        public TaskItemsController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskItemService = await _taskItemService.GetAll();
            return Ok(taskItemService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskItemService = await _taskItemService.GetById(id);

            if (taskItemService == null)
            {
                return NotFound();
            }

            return Ok(taskItemService);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskItem taskItemService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _taskItemService.Add(taskItemService);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem taskItemService)
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

            await _taskItemService.Update(taskItemService);
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
