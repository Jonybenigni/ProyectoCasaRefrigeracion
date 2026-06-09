using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Services
{
    public interface ITaskItemService
    {
        // 1. Obtener todos los elementos de tarea
        Task<List<TaskItem>> GetAll();

        // 2. Obtener un elemento de tarea por su Id

        Task<TaskItem> GetById(int id);

        // 3. Agregar un elemento de tarea nuevo

        Task Add(TaskItem taskItem);

        // 4. Actualizar un elemento de tarea existente
        Task Update(TaskItem taskItem);

        // 5. Eliminar un elemento de tarea
        Task Delete(int id);





    }
}
