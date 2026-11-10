using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.PendingJob;
using Refrigeracion.Entities;
using Refrigeracion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Refrigeracion.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PendingJobsController : ControllerBase
    {
        private readonly IPendingJobService _pendingJobService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public PendingJobsController(IPendingJobService pendingJobService, ICustomerService customerService, IMapper mapper)
        {
            _pendingJobService = pendingJobService;
            _customerService = customerService;
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
            // El cliente tiene que existir: si no, la base rechaza el alta y la API devolveria 500
            if (await _customerService.GetById(request.CustomerId) == null)
            {
                return BadRequest("El cliente elegido no existe.");
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
            if (await _customerService.GetById(request.CustomerId) == null)
            {
                return BadRequest("El cliente elegido no existe.");
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