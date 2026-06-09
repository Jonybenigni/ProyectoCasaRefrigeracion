using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions.Repository;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly RefrigeracionDbContext _context;
        public SupplierRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }
        public async Task Add(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }


    }
}