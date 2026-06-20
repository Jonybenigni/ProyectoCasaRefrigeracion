using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.ProductSupplier;
using Refrigeracion.Entities;
using Refrigeracion.Services;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSuppliersController : ControllerBase
    {
        private readonly IProductSupplierService _productSupplierService;
        private readonly IMapper _mapper;

        public ProductSuppliersController(IProductSupplierService productSupplierService, IMapper mapper)
        {
            _productSupplierService = productSupplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productSuppliers = await _productSupplierService.GetAll();
            var result = _mapper.Map<List<ProductSupplierResponseDto>>(productSuppliers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productSupplier = await _productSupplierService.GetById(id);
            if (productSupplier == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ProductSupplierResponseDto>(productSupplier);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductSupplierRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var productSupplier = _mapper.Map<ProductSupplier>(request);
            await _productSupplierService.Add(productSupplier);
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
