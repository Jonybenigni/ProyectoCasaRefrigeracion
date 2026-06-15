using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController:ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplier = await _supplierService.GetAll();
            return Ok(supplier);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _supplierService.Add(supplier);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existing = await _supplierService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _supplierService.Update(supplier);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _supplierService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _supplierService.Delete(id);
            return Ok();
        }
    }


}

