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
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            var result=_mapper.Map<GetCategoryByIdQueryResult>(value);
            return result;
            //return new GetCategoryByIdQueryResult
            //{
            //    CategoryId = value.CategoryId,
            //    Description = value.Description,
            //    Name=value.Name,
            //};
        }
    }
}
