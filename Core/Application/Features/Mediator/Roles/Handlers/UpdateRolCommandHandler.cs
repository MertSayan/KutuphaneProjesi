using Application.Constants;
using Application.Features.Mediator.Roles.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Handlers
{
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand>
    {
        private readonly IRepository<Role> _repository;

        public UpdateRolCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.RoleId);
            if (value != null)
            {
                value.Name = request.Name;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Role>.EntityNotFound);
            }
        }
    }
}
