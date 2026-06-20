using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions.Repository;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class SupplierPaymentRepository : ISupplierPaymentRepository
    {
        private readonly RefrigeracionDbContext _context;

        public SupplierPaymentRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierPayment>> GetAll()
        {
            return await _context.SupplierPayments
                .Include(s => s.Supplier)
                .ToListAsync();
        }

        public async Task<SupplierPayment> GetById(int id)
        {
            return await _context.SupplierPayments
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Add(SupplierPayment supplierPayment)
        {
            await _context.SupplierPayments.AddAsync(supplierPayment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SupplierPayment supplierPayment)
        {
            _context.SupplierPayments.Update(supplierPayment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var supplierPayment = await _context.SupplierPayments.FindAsync(id);
            if (supplierPayment != null)
            {
                _context.SupplierPayments.Remove(supplierPayment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
