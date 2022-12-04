﻿using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

                User user = await _userRepository.GetAsync(u => u.Id == request.Id);
                UserDto mappedUserDto = _mapper.Map<UserDto>(user);
                return mappedUserDto;

            }
        }
    }
}
