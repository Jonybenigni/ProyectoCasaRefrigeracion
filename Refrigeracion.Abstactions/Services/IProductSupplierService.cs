using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Services
{
    public interface IProductSupplierService
    {
        // 1. Obtener todas las relaciones
        Task<List<ProductSupplier>> GetAll();

        // 2. Obtener una relación por su Id
        Task<ProductSupplier> GetById(int id);

        // 3. Agregar una relación nueva
        Task Add(ProductSupplier productSupplier);

        // 4. Eliminar una relación
        Task Delete(int id);


    }
}
