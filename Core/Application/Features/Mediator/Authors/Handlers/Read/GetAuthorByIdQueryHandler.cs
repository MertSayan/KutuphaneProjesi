using Application.Features.Mediator.Authors.Queries;
using Application.Features.Mediator.Authors.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Authors.Handlers.Read
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery,GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                return new GetAuthorByIdQueryResult
                {
                    AuthorId = value.AuthorId,
                    Name = value.Name,
                };
            }
            //throw new EntityNotFoundException("A");
            //throw new EntityNotFoundException("Author not found");
            //throw new Exception("Bulunamadi");
            return null;
        }
    }
}
