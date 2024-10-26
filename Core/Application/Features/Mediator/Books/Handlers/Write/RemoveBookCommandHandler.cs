using Application.Features.Mediator.Books.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Handlers.Write
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand>
    {
        private readonly IRepository<Book> _repository;

        public RemoveBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
        }
    }
}
