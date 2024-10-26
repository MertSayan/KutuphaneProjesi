using Application.Features.Mediator.Users.Queries;
using Application.Features.Mediator.Users.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Users.Handlers.Read
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if(value != null)
            {
                return new GetUserByIdQueryResult
                {
                    Email = value.Email,
                    Name = value.Name,
                    Password = value.Password,
                    RoleId = value.RoleId,
                    UserId = value.UserId,
                };
            }
            return null;
        }
    }
}
