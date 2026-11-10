using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Application.DTOs.SupplierPayment;
using Refrigeracion.Entities;
using Refrigeracion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Refrigeracion.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierPaymentsController : ControllerBase
    {
        private readonly ISupplierPaymentService _supplierPaymentService;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierPaymentsController(ISupplierPaymentService supplierPaymentService, ISupplierService supplierService, IMapper mapper)
        {
            _supplierPaymentService = supplierPaymentService;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplierPayments = await _supplierPaymentService.GetAll();
            var result = _mapper.Map<List<SupplierPaymentResponseDto>>(supplierPayments);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplierPayment = await _supplierPaymentService.GetById(id);
            if (supplierPayment == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<SupplierPaymentResponseDto>(supplierPayment);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplierPaymentRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // El proveedor tiene que existir: si no, la base rechaza el alta y la API devolveria 500
            if (await _supplierService.GetById(request.SupplierId) == null)
            {
                return BadRequest("El proveedor elegido no existe.");
            }
            var supplierPayment = _mapper.Map<SupplierPayment>(request);
            await _supplierPaymentService.Add(supplierPayment);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupplierPaymentRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existing = await _supplierPaymentService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            if (await _supplierService.GetById(request.SupplierId) == null)
            {
                return BadRequest("El proveedor elegido no existe.");
            }
            _mapper.Map(request, existing);
            await _supplierPaymentService.Update(existing);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _supplierPaymentService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _supplierPaymentService.Delete(id);
            return Ok();
        }
    }
}