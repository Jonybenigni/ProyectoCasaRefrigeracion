using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Services
{
    public interface ISupplierPaymentService
    {
        // 1. Obtener todos los pagos a proveedores
        Task<List<SupplierPayment>> GetAll();

        // 2. Obtener un pago a proveedor por su Id

        Task<SupplierPayment> GetById(int id);

        // 3. Agregar un pago a proveedor nuevo

        Task Add(SupplierPayment supplierPayment);

        // 4. Actualizar un pago a proveedor existente

        Task Update(SupplierPayment supplierPayment);

        // 5. Eliminar un pago a proveedor
        Task Delete(int id);


    }
}
