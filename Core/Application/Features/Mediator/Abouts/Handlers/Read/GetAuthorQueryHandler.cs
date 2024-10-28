using Application.Features.Mediator.Abouts.Queries;
using Application.Features.Mediator.Abouts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Abouts.Handlers.Read
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            var result=_mapper.Map<List<GetAboutQueryResult>>(value);
            return result;


            //return value.Select(x=> new GetAboutQueryResult
            //{
            //    AboutId = x.AboutId,
            //    Name=x.Name,
            //}).ToList();
        }
    }
}
