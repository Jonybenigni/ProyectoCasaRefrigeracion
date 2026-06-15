using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            await _productService.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existing = await _productService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _productService.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _productService.Delete (id);
            return Ok();
        }
    }
}
