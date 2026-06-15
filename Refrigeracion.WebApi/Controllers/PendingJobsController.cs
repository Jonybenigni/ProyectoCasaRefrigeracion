using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingJobsController : ControllerBase
    {
        private readonly IPendingJobService _pendingJobService;
        public PendingJobsController(IPendingJobService pendingJobService)
        {
            _pendingJobService = pendingJobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pendingJobService = await _pendingJobService.GetAll();
            return Ok(pendingJobService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pendingJobService = await _pendingJobService.GetById(id);

            if (pendingJobService == null)
            {
                return NotFound();
            }

            return Ok(pendingJobService);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PendingJob pendingJobService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _pendingJobService.Add(pendingJobService);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PendingJob pendingJobService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existing = await _pendingJobService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _pendingJobService.Update(pendingJobService);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _pendingJobService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _pendingJobService.Delete(id);
            return Ok();
        }





    }
}
