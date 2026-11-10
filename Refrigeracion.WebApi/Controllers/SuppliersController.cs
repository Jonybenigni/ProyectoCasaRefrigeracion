using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.Supplier;
using Refrigeracion.Entities;
using Refrigeracion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Refrigeracion.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAll();
            var result = _mapper.Map<List<SupplierResponseDto>>(suppliers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<SupplierResponseDto>(supplier);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplierRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var supplier = _mapper.Map<Supplier>(request);
            await _supplierService.Add(supplier);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupplierRequestDto request)
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
            _mapper.Map(request, existing);
            await _supplierService.Update(existing);
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
            // La base no deja borrar un proveedor con pagos o productos asociados (sin cascada)
            try
            {
                await _supplierService.Delete(id);
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is InvalidOperationException)
            {
                return BadRequest("No se puede eliminar el proveedor porque tiene pagos o productos asociados.");
            }
            return Ok();
        }
    }
}