using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customerService = await _customerService.GetAll();
            return Ok(customerService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerService = await _customerService.GetById(id);

            if (customerService == null)
            {
                return NotFound();
            }

            return Ok(customerService);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customerService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerService.Add(customerService);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customerService)
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

            await _customerService.Update(customerService);
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
