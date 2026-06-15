using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierPaymentsController : ControllerBase
    {
        private readonly ISupplierPaymentService _supplierPayment;

        public SupplierPaymentsController(ISupplierPaymentService supplierPayment)
        {
            _supplierPayment = supplierPayment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplierPayment = await _supplierPayment.GetAll();
            return Ok(supplierPayment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplierPayment = await _supplierPayment.GetById(id);

            if (supplierPayment == null)
            {
                return NotFound();
            }

            return Ok(supplierPayment);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplierPayment supplierPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _supplierPayment.Add(supplierPayment);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupplierPayment supplierPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existing = await _supplierPayment.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _supplierPayment.Update(supplierPayment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _supplierPayment.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _supplierPayment.Delete(id);
            return Ok();
        }






    }
}
