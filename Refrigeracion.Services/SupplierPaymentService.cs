using Refrigeracion.Abstactions.Repository;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Services
{
    public class SupplierPaymentService : ISupplierPaymentService
    {
        private readonly ISupplierPaymentRepository _supplierPaymentRepository;

        public SupplierPaymentService(ISupplierPaymentRepository supplierPaymentRepository)
        {
            _supplierPaymentRepository = supplierPaymentRepository;
        }
        public async Task Add(SupplierPayment supplierPayment)
        {
            await _supplierPaymentRepository.Add(supplierPayment);
        }

        public async Task Delete(int id)
        {
            await _supplierPaymentRepository.Delete(id);
        }

        public async Task<List<SupplierPayment>> GetAll()
        {
            return await _supplierPaymentRepository.GetAll();
        }

        public async Task<SupplierPayment> GetById(int id)
        {
            return await _supplierPaymentRepository.GetById(id);
        }

        public async Task Update(SupplierPayment supplierPayment)
        {
            await _supplierPaymentRepository.Update(supplierPayment);
        }
    }
}
