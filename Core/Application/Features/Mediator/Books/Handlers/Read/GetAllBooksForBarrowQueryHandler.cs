using Application.Features.Mediator.Books.Queries;
using Application.Features.Mediator.Books.Results;
using Application.Interfaces.BookInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Handlers.Read
{
    public class GetAllBooksForBarrowQueryHandler : IRequestHandler<GetAllBooksForBarrowQuery, List<GetAllBooksForBarrowQueryResult>>
    {
        private readonly IBookRepository _repository;

        public GetAllBooksForBarrowQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBooksForBarrowQueryResult>> Handle(GetAllBooksForBarrowQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.HepsiniTopla();
            return values.Select(x => new GetAllBooksForBarrowQueryResult
            {
                AuthorName=x.Author.Name,
                BookId=x.BookId,
                BookImageUrl=x.BookImageUrl,
                CategoryName=x.Category.Name,
                Description=x.Description,
                PublisherName=x.Publisher.Name,
                Title = x.Title
            }).ToList();
        }
    }
}
