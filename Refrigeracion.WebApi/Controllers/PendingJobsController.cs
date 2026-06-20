using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.PendingJob;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingJobsController : ControllerBase
    {
        private readonly IPendingJobService _pendingJobService;
        private readonly IMapper _mapper;

        public PendingJobsController(IPendingJobService pendingJobService, IMapper mapper)
        {
            _pendingJobService = pendingJobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pendingJobs = await _pendingJobService.GetAll();
            var result = _mapper.Map<List<PendingJobResponseDto>>(pendingJobs);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pendingJob = await _pendingJobService.GetById(id);
            if (pendingJob == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<PendingJobResponseDto>(pendingJob);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PendingJobRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var pendingJob = _mapper.Map<PendingJob>(request);
            await _pendingJobService.Add(pendingJob);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PendingJobRequestDto request)
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
            _mapper.Map(request, existing);
            await _pendingJobService.Update(existing);
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