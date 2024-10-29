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
    public class GetAllBooksWithCatAutPubQueryHandler : IRequestHandler<GetAllBooksWithCatAutPubQuery, List<GetAllBooksWithCatAutPubQueryResult>>
    {
        private readonly IBookRepository _repository;

        public GetAllBooksWithCatAutPubQueryHandler(IBookRepository reposRepository)
        {
            _repository = reposRepository;
        }

        public async Task<List<GetAllBooksWithCatAutPubQueryResult>> Handle(GetAllBooksWithCatAutPubQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.HepsiniTopla();
            return values.Select(x => new GetAllBooksWithCatAutPubQueryResult
            {
                AuthorName=x.Author.Name,
                CategoryName=x.Category.Name,
                PublisherName=x.Publisher.Name,
            }).ToList();
        }
    }
}
