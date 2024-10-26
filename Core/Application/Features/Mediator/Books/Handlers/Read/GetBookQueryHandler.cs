using Application.Features.Mediator.Books.Queries;
using Application.Features.Mediator.Books.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Handlers.Read
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery,List<GetBookQueryResult>>
    {
        private readonly IRepository<Book> _repository;

        public GetBookQueryHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBookQueryResult>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetBookQueryResult
            {
                AuthorId = x.AuthorId,
                BookId = x.BookId,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Language = x.Language,
                Title = x.Title,
                TotalCopies=x.TotalCopies,
                AvailableCopies=x.AvailableCopies,
                PublisherId = x.PublisherId

            }).ToList();
        }
    }
}
