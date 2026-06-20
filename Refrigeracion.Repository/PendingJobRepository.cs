using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions.Repository;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class PendingJobRepository : IPendingJobRepository
    {
        private readonly RefrigeracionDbContext _context;

        public PendingJobRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task<List<PendingJob>> GetAll()
        {
            return await _context.PendingJobs
                .Include(p => p.Customer)
                .ToListAsync();
        }

        public async Task<PendingJob> GetById(int id)
        {
            return await _context.PendingJobs
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(PendingJob pendingJob)
        {
            await _context.PendingJobs.AddAsync(pendingJob);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PendingJob pendingJob)
        {
            _context.PendingJobs.Update(pendingJob);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pendingJob = await _context.PendingJobs.FindAsync(id);
            if (pendingJob != null)
            {
                _context.PendingJobs.Remove(pendingJob);
                await _context.SaveChangesAsync();
            }
        }
    }
}
