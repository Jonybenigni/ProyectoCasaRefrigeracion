using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Services
{
    public interface IPendingJobService
    {
        // 1. Obtener todos los trabajos pendientes
        Task<List<PendingJob>> GetAll();

        // 2. Obtener un trabajo pendiente por su Id

        Task<PendingJob> GetById(int id);

        // 3. Agregar un trabajo pendiente nuevo

        Task Add(PendingJob pendingJob);

        // 4. Actualizar un trabajo pendiente existente

        Task Update(PendingJob pendingJob);

        // 5. Eliminar un trabajo pendiente
        Task Delete(int id);




    }
}
