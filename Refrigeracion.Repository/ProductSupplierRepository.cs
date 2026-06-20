using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions.Repository;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class ProductSupplierRepository : IProductSupplierRepository
    {
        private readonly RefrigeracionDbContext _context;

        public ProductSupplierRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductSupplier productSupplier)
        {
            await _context.ProductSuppliers.AddAsync(productSupplier);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productSupplier = await _context.ProductSuppliers.FindAsync(id);

            if (productSupplier != null)
            {
                _context.ProductSuppliers.Remove(productSupplier);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<ProductSupplier>> GetAll()
        {
            return await _context.ProductSuppliers
                .Include(ps => ps.Product)
                .Include(ps => ps.Supplier)
                .ToListAsync();
        }

        public async Task<ProductSupplier> GetById(int id)
        {
            return await _context.ProductSuppliers
                .Include(ps => ps.Product)
                .Include(ps => ps.Supplier)
                .FirstOrDefaultAsync(ps => ps.Id == id);
        }




    }
}
