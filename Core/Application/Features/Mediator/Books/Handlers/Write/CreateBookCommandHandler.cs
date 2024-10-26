using Application.Features.Mediator.Books.Commands;
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
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IRepository<Book> _repository;

        public CreateBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {

            var existingBooks = await _repository.FindByConditionAsync(x => x.Title.ToLower() == command.Title && x.PublisherId == command.PublisherId);

            if (existingBooks != null && existingBooks.Count > 0)
            {
                var existingBook = existingBooks.First();
                existingBook.TotalCopies++;
                existingBook.AvailableCopies++;
                await _repository.UpdateAsync(existingBook);
            }
            else
            {
                //bir anda 5 kitap eklemek isterse diye totalcopies kısmını ekledim burada revizeye gidilebilir.
                await _repository.CreateAsync(new Book
                {
                    AuthorId = command.AuthorId,
                    CategoryId = command.CategoryId,
                    Description = command.Description,
                    Language = command.Language,
                    PublisherId = command.PublisherId,
                    Title = command.Title,
                    TotalCopies = command.TotalCopies,
                    AvailableCopies = command.AvailableCopies,
                });
            }
           

            //await _repository.CreateAsync(new Book
            //{
            //    AuthorId = request.AuthorId,
            //    CategoryId = request.CategoryId,
            //    Description = request.Description,
            //    Language = request.Language,
            //    PublisherId = request.PublisherId,
            //    Title = request.Title,
            //});
        }

        public async Task<bool> CreateBookIsAlreadyHas(CreateBookCommand command)
        {
            var existingBooks = await _repository.FindByConditionAsync(x=>x.Title.ToLower()==command.Title && x.PublisherId==command.PublisherId);

            if (existingBooks != null && existingBooks.Count > 0)
            {
                var existingBook = existingBooks.First();
                existingBook.TotalCopies++;
                existingBook.AvailableCopies++;
                await _repository.UpdateAsync(existingBook);
                return true;
            }
            await _repository.CreateAsync(new Book
            {
                AuthorId = command.AuthorId,
                CategoryId = command.CategoryId,
                Description = command.Description,
                Language = command.Language,
                PublisherId = command.PublisherId,
                Title = command.Title,
                TotalCopies = command.TotalCopies,
                AvailableCopies = command.AvailableCopies,
            });
            return true;
        }
    }
}
