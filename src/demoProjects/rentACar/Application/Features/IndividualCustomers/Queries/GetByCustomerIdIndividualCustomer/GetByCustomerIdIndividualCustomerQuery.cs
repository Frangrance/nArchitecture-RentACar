using Application.Features.Customers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Queries.GetByCustomerIdIndividualCustomer
{
    public class GetByCustomerIdIndividualCustomerQuery : IRequest<IndividualCustomer>
    {
        public int CustomerId { get; set; }

        public class GetByCustomerIdIndividualCustomerQueryHandler : IRequestHandler<GetByCustomerIdIndividualCustomerQuery, IndividualCustomer>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

            public GetByCustomerIdIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<IndividualCustomer> Handle(GetByCustomerIdIndividualCustomerQuery request, CancellationToken cancellationToken)
            { 
                IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(i => i.CustomerId == request.CustomerId);
                await _individualCustomerBusinessRules.IndividualCustomerShouldBeExist(individualCustomer);
                IndividualCustomer mappedCustomerDto =_mapper.Map<IndividualCustomer>(individualCustomer);
                return mappedCustomerDto;
            }
        }
    }
}
