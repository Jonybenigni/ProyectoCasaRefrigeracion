using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions
{
    public interface ISupplierPaymentRepository
    {
        Task<List<SupplierPayment>> GetAll();
        Task<SupplierPayment> GetById(int id);
        Task Add(SupplierPayment supplierPayment);
        Task Update(SupplierPayment supplierPayment);
        Task Delete(int id);
    }
}
