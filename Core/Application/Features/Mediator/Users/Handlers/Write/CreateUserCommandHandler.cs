using Application.Enums;
using Application.Features.Mediator.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Users.Handlers.Write
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            await _repository.CreateAsync(user);

            //await _repository.CreateAsync(new User
            //{
            //    Email = request.Email,
            //    Name = request.Name,
            //    Password = request.Password,
            //    RoleId = (int)Rol.Üye,
                
            //});
        }
    }
}
