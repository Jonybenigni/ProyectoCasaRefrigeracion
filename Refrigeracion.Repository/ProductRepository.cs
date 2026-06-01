using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RefrigeracionDbContext _context;

        public ProductRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null) 
            {
                 _context.Products.Remove(product);
                 await _context.SaveChangesAsync();
             
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        
    }
}
