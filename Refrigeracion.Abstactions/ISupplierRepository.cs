using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions
{
    public interface ISupplierRepository
    {
       
          // 1. Obtener todos los proveedores
          Task<List<Supplier>> GetAll();

          // 2. Obtener un proveedor por su Id

          Task<Supplier> GetById(int id);

            // 3. Agregar un proveedor nuevo        
          Task Add(Supplier supplier);

          // 4. Actualizar un proveedor existente

          Task Update(Supplier supplier);

          // 5. Eliminar un proveedor

          Task Delete(int id);
        
    }
}
