using Application.Features.Mediator.Barrows.Queries;
using Application.Features.Mediator.Barrows.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Handlers.Read
{
    public class GetBarrowQueryHandler : IRequestHandler<GetBarrowQuery, List<GetBarrowQueryResult>>
    {
        private readonly IRepository<Barrow> _repository;

        public GetBarrowQueryHandler(IRepository<Barrow> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBarrowQueryResult>> Handle(GetBarrowQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetBarrowQueryResult
            {
                BarrowDate=x.BarrowDate,
                BarrowId=x.BarrowId,
                BookId=x.BookId,
                DueDate=x.DueDate,
                IsReturned=x.IsReturned,
                ReturnDate=x.ReturnDate,
                UserId=x.UserId,
            }).ToList();
        }
    }
}
