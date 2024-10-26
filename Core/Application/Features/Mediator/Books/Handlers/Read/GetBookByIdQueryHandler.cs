using Application.Features.Mediator.Books.Queries;
using Application.Features.Mediator.Books.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Handlers.Read
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryResult>
    {
        private readonly IRepository<Book> _repository;

        public GetBookByIdQueryHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<GetBookByIdQueryResult> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if(value != null)
            {
                return new GetBookByIdQueryResult
                {
                    AuthorId = value.AuthorId,
                    BookId = value.BookId,
                    CategoryId = value.CategoryId,
                    Description = value.Description,
                    Language = value.Language,
                    Title = value.Title,
                    TotalCopies = value.TotalCopies,
                    AvailableCopies = value.AvailableCopies,
                    PublisherId = value.PublisherId
                };
            }
            return null;
        }
    }
}
