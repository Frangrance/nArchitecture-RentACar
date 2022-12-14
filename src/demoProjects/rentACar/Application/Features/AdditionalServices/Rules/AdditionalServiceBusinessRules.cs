using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdditionalServices.Rules
{
    public class AdditionalServiceBusinessRules
    {
        private readonly IAdditionalServiceRepository _additionalServiceRepository;

        public AdditionalServiceBusinessRules(IAdditionalServiceRepository additionalServiceRepository)
        {
            _additionalServiceRepository = additionalServiceRepository;
        }
        public async Task AdditionalServiceIdShouldExistWhenSelected(int id)
        {
             AdditionalService? result = await _additionalServiceRepository.GetAsync(a => a.Id == id);
            if (result is null) throw new BusinessException("Additional service not exists.");
        }
        public async Task AdditionalServiceNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<AdditionalService> result = await _additionalServiceRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException("Additional service name exists.");
        }

    }
}
