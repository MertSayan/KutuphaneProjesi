using Application.Constants;
using Application.Features.Mediator.Roles.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Roles.Handlers
{
    public class RemoveRolCommandHandler : IRequestHandler<RemoveRolCommand>
    {
        private readonly IRepository<Role> _repositories;

        public RemoveRolCommandHandler(IRepository<Role> repositories)
        {
            _repositories = repositories;
        }

        public async Task Handle(RemoveRolCommand request, CancellationToken cancellationToken)
        {
            var value=await _repositories.GetByIdAsync(request.Id);
            if(value != null)
            {
                await _repositories.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<Role>.EntityNotFound);
            }
        }
    }
}
