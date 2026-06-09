using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Abstactions.Repository
{
    public interface IPendingJobRepository
    {
        Task<List<PendingJob>> GetAll();
        Task<PendingJob> GetById(int id);
        Task Add(PendingJob pendingJob);
        Task Update(PendingJob pendingJob);
        Task Delete(int id);
    }
}
