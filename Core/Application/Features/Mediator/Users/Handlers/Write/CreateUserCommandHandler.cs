using Application.Enums;
using Application.Features.Mediator.Users.Commands;
using Application.Interfaces;
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

        public CreateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                RoleId = (int)Rol.Üye,
                
            });
        }
    }
}
