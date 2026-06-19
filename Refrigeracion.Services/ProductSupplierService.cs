using Refrigeracion.Abstactions.Repository;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Services
{
    public class ProductSupplierService:IProductSupplierService
    {
        private readonly IProductSupplierRepository _productSupplierRepository;

        public ProductSupplierService(IProductSupplierRepository productSupplierRepository)
        {
            _productSupplierRepository = productSupplierRepository;
        }

        public async Task Add(ProductSupplier productSupplier)
        {
            await _productSupplierRepository.Add(productSupplier);
        }

        public async Task Delete(int id)
        {
            await _productSupplierRepository.Delete(id);
        }

        public async Task<List<ProductSupplier>> GetAll()
        {
            return await _productSupplierRepository.GetAll();
        }

        public async Task<ProductSupplier> GetById(int id)
        {
            return await _productSupplierRepository.GetById(id);
        }
    }
}
