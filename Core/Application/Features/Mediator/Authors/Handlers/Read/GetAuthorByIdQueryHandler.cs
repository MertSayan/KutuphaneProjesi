using Application.Features.Mediator.Authors.Queries;
using Application.Features.Mediator.Authors.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Authors.Handlers.Read
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery,GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                var result = _mapper.Map<GetAuthorByIdQueryResult>(value);
                return result;
            }
            else
            {
                return null;
            }



            //if (value != null)
            //{
            //    return new GetAuthorByIdQueryResult
            //    {
            //        AuthorId = value.AuthorId,
            //        Name = value.Name,
            //    };
            //}

            //return null;
        }
    }
}
