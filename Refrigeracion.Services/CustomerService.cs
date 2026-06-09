using Refrigeracion.Abstactions.Repository;
using Refrigeracion.Abstactions.Services;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository  _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task Add(Customer customer)
        {
            await _customerRepository.Add(customer);
        }

        public async Task Delete(int id)
        {
            await _customerRepository.Delete(id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task Update(Customer customer)
        {
            await _customerRepository.Update(customer);
        }
    }
}
