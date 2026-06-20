using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.Customer;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAll();
            var result = _mapper.Map<List<CustomerResponseDto>>(customers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<CustomerResponseDto>(customer);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = _mapper.Map<Customer>(request);
            await _customerService.Add(customer);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existing = await _customerService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            _mapper.Map(request, existing);
            await _customerService.Update(existing);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _customerService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _customerService.Delete(id);
            return Ok();
        }
    }
}