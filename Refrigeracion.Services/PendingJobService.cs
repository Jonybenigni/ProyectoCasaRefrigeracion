using Refrigeracion.Abstactions.Repository;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Services
{
    public class PendingJobService:IPendingJobService
    {
        private readonly IPendingJobRepository _pendingJobRepository;

        public PendingJobService(IPendingJobRepository pendingJobRepository)
        {
            _pendingJobRepository = pendingJobRepository;
        }
        public async Task<List<PendingJob>> GetAll()
        {
            return await _pendingJobRepository.GetAll();
        }

        public async Task<PendingJob> GetById(int id)
        {
            return await _pendingJobRepository.GetById(id);
        }

        public async Task Add(PendingJob pendingJob)
        {
            await _pendingJobRepository.Add(pendingJob);
        }

        public async Task Update(PendingJob pendingJob)
        {
            await _pendingJobRepository.Update(pendingJob);
        }

        public async Task Delete(int id)
        {
           await _pendingJobRepository.Delete(id);
        }

        

    }
}
