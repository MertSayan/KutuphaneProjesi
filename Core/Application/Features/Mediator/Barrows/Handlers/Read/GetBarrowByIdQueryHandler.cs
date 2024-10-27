using Application.Features.Mediator.Barrows.Queries;
using Application.Features.Mediator.Barrows.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Barrows.Handlers.Read
{
    public class GetBarrowByIdQueryHandler : IRequestHandler<GetBarrowByIdQuery, GetBarrowByIdQueryResult>
    {
        private readonly IRepository<Barrow> _repository;
        private readonly IMapper _mapper;

        public GetBarrowByIdQueryHandler(IRepository<Barrow> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBarrowByIdQueryResult> Handle(GetBarrowByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {

                var result=_mapper.Map<GetBarrowByIdQueryResult>(value);
                return result;

                //return new GetBarrowByIdQueryResult
                //{
                //    BarrowDate = value.BarrowDate,
                //    BarrowId = request.Id,
                //    BookId = request.Id,
                //    DueDate = value.DueDate,
                //    IsReturned = true,
                //    ReturnDate = value.ReturnDate,
                //    UserId = request.Id
                //};
            }
            else
            {
                return null;
            }
        }
    }
}
