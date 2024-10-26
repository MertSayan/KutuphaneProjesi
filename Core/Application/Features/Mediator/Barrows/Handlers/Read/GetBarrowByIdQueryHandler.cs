using Application.Features.Mediator.Barrows.Queries;
using Application.Features.Mediator.Barrows.Results;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Barrows.Handlers.Read
{
    public class GetBarrowByIdQueryHandler : IRequestHandler<GetBarrowByIdQuery, GetBarrowByIdQueryResult>
    {
        private readonly IRepository<Barrow> _repository;

        public GetBarrowByIdQueryHandler(IRepository<Barrow> repository)
        {
            _repository = repository;
        }

        public async Task<GetBarrowByIdQueryResult> Handle(GetBarrowByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                return new GetBarrowByIdQueryResult
                {
                    BarrowDate = DateTime.Now,
                    BarrowId = request.Id,
                    BookId = request.Id,
                    DueDate = DateTime.Now,
                    IsReturned = true,
                    ReturnDate = DateTime.Now,
                    UserId = request.Id
                };
            }
            else
            {
                return null;
            }
        }
    }
}
