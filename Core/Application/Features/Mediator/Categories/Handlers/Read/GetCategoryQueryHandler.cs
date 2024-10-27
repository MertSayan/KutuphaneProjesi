using Application.Features.Mediator.Categories.Queries;
using Application.Features.Mediator.Categories.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Handlers.Read
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result=_mapper.Map<List<GetCategoryQueryResult>>(values);
            return result;
            //return values.Select(x=> new GetCategoryQueryResult
            //{
            //    CategoryId = x.CategoryId,
            //    Description = x.Description,
            //    Name=x.Name,
            //}).ToList();
        }
    }
}
