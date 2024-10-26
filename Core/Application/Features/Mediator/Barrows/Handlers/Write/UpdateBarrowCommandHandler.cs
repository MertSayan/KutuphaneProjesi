using Application.Constants;
using Application.Features.Mediator.Barrows.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Barrows.Handlers.Write
{
    public class UpdateBarrowCommandHandler : IRequestHandler<UpdateBarrowCommand>
    {
        private readonly IRepository<Barrow> _repository;
        private readonly IRepository<Book> _bookRepository;

        public UpdateBarrowCommandHandler(IRepository<Barrow> repository, IRepository<Book> bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public async Task Handle(UpdateBarrowCommand request, CancellationToken cancellationToken)
        {
            var barrow= await _repository.GetByIdAsync(request.BarrowId);
            if (barrow != null && barrow.IsReturned!=true)
            {
                barrow.IsReturned = true;
                barrow.DueDate = DateTime.Now;
                await _repository.UpdateAsync(barrow);

                var book=await _bookRepository.GetByIdAsync(barrow.BookId);
                book.AvailableCopies++;
                await _bookRepository.UpdateAsync(book);
            }
            else
            {
                throw new Exception(Messages<Barrow>.EntityNotFound);
            }
        }
    }
}
