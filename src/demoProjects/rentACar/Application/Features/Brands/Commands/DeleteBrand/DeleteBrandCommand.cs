using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Brands.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<DeletedBrandDto>, ISecuredRequest, ICacheRemoverRequest
    {
        public int Id { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => "brands-list";
        public string[] Roles => new[] { Admin, BrandDelete };
        
        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<DeletedBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand deletedBrand = await _brandRepository.DeleteAsync(mappedBrand);
                DeletedBrandDto deletedBrandDto = _mapper.Map<DeletedBrandDto>(deletedBrand);
                return deletedBrandDto;
            }
        }
    }
}
