using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Services
{
    public interface ICustomerService
    {
        // 1. Obtener todos los clientes
        Task<List<Customer>> GetAll();

        // 2. Obtener un cliente por su Id

        Task<Customer> GetById(int id);
        
        // 3. Agregar un cliente nuevo

        Task Add(Customer customer);

        // 4. Actualizar un cliente existente

        Task Update(Customer customer);

        // 5. Eliminar un cliente
        Task Delete(int id);



    }
}
