using Application.Constants;
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
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IRepository<User> _repository;

        public RemoveUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<User>.EntityNotFound);
            }
        }
    }
}
