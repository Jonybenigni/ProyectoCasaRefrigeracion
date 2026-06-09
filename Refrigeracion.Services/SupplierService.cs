using Refrigeracion.Abstactions.Repository;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task Add(Supplier supplier)
        {
            await _supplierRepository.Add(supplier);
        }

        public async Task Delete(int id)
        {
            await _supplierRepository.Delete(id);
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _supplierRepository.GetAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _supplierRepository.GetById(id);
        }

        public async Task Update(Supplier supplier)
        {
            await _supplierRepository.Update(supplier);
        }
    }
}
