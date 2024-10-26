using Application.Features.Mediator.Roles.Queries;
using Application.Features.Mediator.Roles.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Handlers.Read
{
    public class GetRolByIdQueryHandler : IRequestHandler<GetRolByIdQuery, GetRolByIdQueryResult>
    {
        private readonly IRepository<Role> _repository;

        public GetRolByIdQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<GetRolByIdQueryResult> Handle(GetRolByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if(value != null)
            {
                return new GetRolByIdQueryResult
                {
                    Name = value.Name,
                    RoleId=value.RoleId,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
