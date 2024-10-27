using Application.Features.Mediator.Banners.Queries;
using Application.Features.Mediator.Banners.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Banners.Handlers.Read
{
    public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public GetBannerQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result=_mapper.Map<List<GetBannerQueryResult>>(values);
            return result;

            //return values.Select(x=> new GetBannerQueryResult
            //{
            //    BannerId = x.BannerId,
            //    Description = x.Description,
            //    Title= x.Title,
            //}).ToList();
        }
    }
}
