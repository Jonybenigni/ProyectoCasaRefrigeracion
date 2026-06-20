using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.Product;
using Refrigeracion.Entities;

namespace Refrigeracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            var result = _mapper.Map<List<ProductResponseDto>>(products);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ProductResponseDto>(product);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = _mapper.Map<Product>(request);
            await _productService.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductRequestDto request)
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
            _mapper.Map(request, existing);
            await _productService.Update(existing);
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
            await _productService.Delete(id);
            return Ok();
        }
    }
}