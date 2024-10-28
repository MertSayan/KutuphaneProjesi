using Application.Features.Mediator.Abouts.Queries;
using Application.Features.Mediator.Abouts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Abouts.Handlers.Read
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery,GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                var result = _mapper.Map<GetAboutByIdQueryResult>(value);
                return result;
            }
            else
            {
                return null;
            } 
        }
    }
}
