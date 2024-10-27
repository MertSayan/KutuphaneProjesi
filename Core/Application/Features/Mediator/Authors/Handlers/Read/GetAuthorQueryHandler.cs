using Application.Features.Mediator.Authors.Queries;
using Application.Features.Mediator.Authors.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Authors.Handlers.Read
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            var result=_mapper.Map<List<GetAuthorQueryResult>>(value);
            return result;


            //return value.Select(x=> new GetAuthorQueryResult
            //{
            //    AuthorId = x.AuthorId,
            //    Name=x.Name,
            //}).ToList();
        }
    }
}
