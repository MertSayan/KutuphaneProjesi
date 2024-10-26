using Application.Features.Mediator.Roles.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Roles.Handlers
{
    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand>
    {
        private readonly IRepository<Role> _repository;

        public CreateRolCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Role
            {
                Name = request.Name,
                
            });
        }
    }
}
