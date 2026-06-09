using Refrigeracion.Abstactions.Repository;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public async Task Add(TaskItem taskItem)
        {
            await _taskItemRepository.Add(taskItem);
        }

        public async Task Delete(int id)
        {
            await _taskItemRepository.Delete(id);
        }

        public async Task<List<TaskItem>> GetAll()
        {
            return await _taskItemRepository.GetAll();
        }

        public async Task<TaskItem> GetById(int id)
        {
            return await _taskItemRepository.GetById(id);
        }

        public async Task Update(TaskItem taskItem)
        {
            await _taskItemRepository.Update(taskItem);
        }
    }
}
