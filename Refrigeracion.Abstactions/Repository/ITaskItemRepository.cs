using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Repository
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAll();
        Task<TaskItem> GetById(int id);
        Task Add(TaskItem taskItem);
        Task Update(TaskItem taskItem);
        Task Delete(int id);
    }
}
