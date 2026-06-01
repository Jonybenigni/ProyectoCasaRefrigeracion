using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class TaskItemRepository: ITaskItemRepository
    {

        private readonly RefrigeracionDbContext _context;

        public TaskItemRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task Add(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<TaskItem>> GetAll()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> GetById(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task Update(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await _context.SaveChangesAsync();
        }




    }
}
