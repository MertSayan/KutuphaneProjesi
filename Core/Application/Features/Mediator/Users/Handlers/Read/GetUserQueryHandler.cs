using Application.Features.Mediator.Users.Queries;
using Application.Features.Mediator.Users.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Users.Handlers.Read
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result=_mapper.Map<List<GetUserQueryResult>>(values);
            return result;
            //return values.Select(x => new GetUserQueryResult
            //{
            //    Email = x.Email,
            //    Name = x.Name,
            //    Password = x.Password,
            //    RoleId = x.RoleId,
            //    UserId = x.UserId,
            //}).ToList();
        }
    }
}
