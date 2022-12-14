using Application.Features.Colors.Models;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Queries.GetListColor
{
    public class GetListColorQuery : IRequest<ColorListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListColorQueryHandler : IRequestHandler<GetListColorQuery, ColorListModel>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            private readonly ColorBusinessRules _colorBusinessRules;
            public async Task<ColorListModel> Handle(GetListColorQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Color> colors = await _colorRepository.GetListAsync(index:request.PageRequest.Page,
                                                                              size:request.PageRequest.PageSize);
                ColorListModel mappedColorListModel =_mapper.Map<ColorListModel>(colors);
                return mappedColorListModel;
            }
        }
    }
}
