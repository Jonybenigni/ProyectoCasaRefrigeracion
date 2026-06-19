using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSuppliersController:ControllerBase
    {
        private readonly IProductSupplierService _productSupplierService;

        public ProductSuppliersController(IProductSupplierService productSupplierService)
        {
            _productSupplierService = productSupplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productSupplierService = await _productSupplierService.GetAll();
            return Ok(productSupplierService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productSupplierService = await _productSupplierService.GetById(id);

            if (productSupplierService == null)
            {
                return NotFound();
            }

            return Ok(productSupplierService);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductSupplier productSupplierService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productSupplierService.Add(productSupplierService);
            return Ok();
        }

  

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productSupplierService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _productSupplierService.Delete(id);
            return Ok();
        }











    }
}
