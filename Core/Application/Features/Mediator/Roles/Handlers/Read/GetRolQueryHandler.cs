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
    public class GetRolQueryHandler : IRequestHandler<GetRolQuery, List<GetRolQueryResult>>
    {
        private readonly IRepository<Role> _repository;

        public GetRolQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRolQueryResult>> Handle(GetRolQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetRolQueryResult
            {
                Name = x.Name,
                RoleId=x.RoleId,
            }).ToList();
        }
    }
}
