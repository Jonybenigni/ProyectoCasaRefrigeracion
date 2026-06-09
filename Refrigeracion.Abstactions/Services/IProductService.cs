using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Services
{
    public interface IProductService
    {
        // 1. Obtener todos los productos
        Task<List<Product>> GetAll();

        // 2. Obtener un producto por su Id

        Task<Product> GetById(int id);

        // 3. Agregar un producto nuevo

        Task Add(Product product);

        // 4. Actualizar un producto existente

        Task Update(Product product);

        // 5. Eliminar un producto

        Task Delete(int id);



    }
}
