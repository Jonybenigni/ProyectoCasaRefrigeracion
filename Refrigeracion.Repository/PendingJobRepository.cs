using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions.Repository;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class PendingJobRepository: IPendingJobRepository
    {
        private readonly RefrigeracionDbContext _context;

        public PendingJobRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task Add(PendingJob job)
        {
            await _context.PendingJobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var job = await _context.PendingJobs.FindAsync(id);

            if (job != null)
            {
                _context.PendingJobs.Remove(job);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<PendingJob>> GetAll()
        {
            return await _context.PendingJobs.ToListAsync();
        }

        public async Task<PendingJob> GetById(int id)
        {
            return await _context.PendingJobs.FindAsync(id);
        }

        public async Task Update(PendingJob job) 
        {
            _context.PendingJobs.Update(job);
            await _context.SaveChangesAsync();
        }

    }
}
