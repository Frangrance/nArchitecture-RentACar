using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CustomerIdShouldExist(int customerId)
        {
            Customer? result = await _customerRepository.GetAsync(c => c.Id == customerId);
            if (result == null) throw new BusinessException("Customer not exists.");
        }
        public Task CustomerShouldBeExist(Customer? customer)
        {
            if (customer is null) throw new BusinessException("Customer don't exists.");
            retu
    }
}
