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
    public class GetAllBookWithSamePublisherNameQueryHandler : IRequestHandler<GetAllBookWithSamePublisherNameQuery, List<GetAllBookWithSameThingQueryResult>>
    {
        private readonly IBookRepository _repository;

        public GetAllBookWithSamePublisherNameQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBookWithSameThingQueryResult>> Handle(GetAllBookWithSamePublisherNameQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllBooksWithParametres(x => x.Publisher.Name.ToLower() == request.PublisherName.ToLower());
            return value.Select(x => new GetAllBookWithSameThingQueryResult
            {
                AuthorName = x.Author.Name,
                BookId = x.BookId,
                BookImageUrl = x.BookImageUrl,
                CategoryName = x.Category.Name,
                Description = x.Description,
                PublisherName = x.Publisher.Name,
                Title = x.Title,
            }).ToList();
        }
    }
}
