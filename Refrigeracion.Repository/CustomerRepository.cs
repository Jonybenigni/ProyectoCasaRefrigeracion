using Microsoft.EntityFrameworkCore;
using Refrigeracion.Abstactions;
using Refrigeracion.DataAccess;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly RefrigeracionDbContext _context;

        public CustomerRepository(RefrigeracionDbContext context)
        {
            _context = context;
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }





    }
}
