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
    public class GetBookWithBarrowCountQueryHandler : IRequestHandler<GetBookWithBarrowCountQuery, List<GetBookWithBarrowCountQueryResult>>
    {
        private readonly IBookRepository _repository;

        public GetBookWithBarrowCountQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBookWithBarrowCountQueryResult>> Handle(GetBookWithBarrowCountQuery request, CancellationToken cancellationToken)
        {
            //burayı mapper ile ypamayı dene bir ara
            var values = await _repository.GetTopBorrowedBooksAsync();
            return values.Select(x => new GetBookWithBarrowCountQueryResult
            {
                BookId = x.BookId,
                AvailableCopies = x.AvailableCopies,
                CategoryName=x.Category.Name,
                AuthorName=x.Author.Name,
                BookImageUrl=x.BookImageUrl,
                PublisherName=x.Publisher.Name,
                Title=x.Title,

            }).ToList();
        }
    }
}
