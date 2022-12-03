using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetByIdCustomer
{
    public class GetByIdCustomerQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }

        public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _customerBusinessRules;

            public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository,
                                               CustomerBusinessRules customerBusinessRules, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(c => c.Id == request.Id);
                await _customerBusinessRules.CustomerShouldBeExist(customer);
                CustomerDto mappedCustomerDto = _mapper.Map<CustomerDto>(customer);
                return mappedCustomerDto;
            }
        }
    }
}
