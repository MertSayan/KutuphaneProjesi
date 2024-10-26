using Application.Constants;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.UserId);
            if (value != null)
            {
                value.Email = request.Email;
                value.Name = request.Name;
                value.Password = request.Password;
                value.RoleId = (int)Rol.Üye;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<User>.EntityNotFound);
            }
        }
    }
}
