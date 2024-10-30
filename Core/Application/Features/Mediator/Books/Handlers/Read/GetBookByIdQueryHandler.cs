using Application.Features.Mediator.Books.Queries;
using Application.Features.Mediator.Books.Results;
using Application.Interfaces;
using Application.Interfaces.BookInterface;
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
        private readonly IBookRepository _repository;

        public GetBookByIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBookByIdQueryResult> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBookById(request.Id);
            if(value != null)
            {
                return new GetBookByIdQueryResult
                {
                    AuthorName = value.Author.Name,
                    BookId = value.BookId,
                    CategoryName = value.Category.Name,
                    Description = value.Description,
                    Language = value.Language,
                    Title = value.Title,
                    TotalCopies = value.TotalCopies,
                    AvailableCopies = value.AvailableCopies,
                    PublisherName = value.Publisher.Name,
                    BookImageUrl= value.BookImageUrl,
                };
            }
            return null;
        }
    }
}
