using Application.Features.Customers.Dtos;
using Application.Features.IndividualCustomers.Dtos;
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
    public class GetByCustomerIdIndividualCustomerQuery : IRequest<IndividualCustomerDto>
    {
        public int CustomerId { get; set; }

        public class GetByCustomerIdIndividualCustomerQueryHandler : IRequestHandler<GetByCustomerIdIndividualCustomerQuery, IndividualCustomerDto>
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

            public async Task<IndividualCustomerDto> Handle(GetByCustomerIdIndividualCustomerQuery request, CancellationToken cancellationToken)
            { 
                IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(i => i.CustomerId == request.CustomerId);
                await _individualCustomerBusinessRules.IndividualCustomerShouldBeExist(individualCustomer);
                IndividualCustomerDto mappedCustomerDto =_mapper.Map<IndividualCustomerDto>(individualCustomer);
                return mappedCustomerDto;
            }
        }
    }
}
