using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Users.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<CreatedUserDto>, ISecuredRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string[] Roles => new[] { Admin, UserAdd };

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User mappedUser = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                passwordHash = mappedUser.PasswordHash;
                passwordSalt = mappedUser.PasswordSalt;

                User createdUser = await _userRepository.AddAsync(mappedUser);
                CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);
                return createdUserDto;
            }
        }
    }
}
