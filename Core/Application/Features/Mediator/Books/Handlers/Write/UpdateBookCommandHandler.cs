using Application.Constants;
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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IRepository<Book> _repository;

        public UpdateBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {

            var findBook=await _repository.GetByIdAsync(request.BookId);
            if(findBook != null)
            {
                if(findBook.TotalCopies>1)
                {
                    if(findBook.Title!=request.Title||findBook.PublisherId!=request.PublisherId||
                        findBook.Description != request.Description|| findBook.Language != request.Language||
                        findBook.CategoryId!= request.CategoryId)
                    {
                        Book book=new Book();

                       book.Title = request.Title;
                       book.PublisherId = request.PublisherId;
                       book.Description = request.Description;
                       book.Language = request.Language;
                       book.CategoryId = request.CategoryId;
                        book.AuthorId= request.AuthorId;
                        
                       findBook.AvailableCopies--;
                       findBook.TotalCopies--;
                        await _repository.UpdateAsync(findBook);
                        await _repository.CreateAsync(book);
                    }
                }
                else
                {
                   findBook.AuthorId = request.AuthorId;
                    findBook.PublisherId = request.PublisherId;                  
                   findBook.Title = request.Title;
                    findBook.Description = request.Description; 
                    findBook.Language = request.Language;
                    findBook.CategoryId = request.CategoryId;
                    await _repository.UpdateAsync(findBook);
                }
            }
            else
            {
                throw new Exception(Messages<Book>.EntityNotFound);
            }




            //var existingBook = await _repository.FindByConditionAsync(x => x.Title.ToLower() == request.Title && x.PublisherId == request.PublisherId);

            //if (existingBook != null && existingBook.Count > 0)
            //{
            //    // Kitabı güncelle
            //    var bookToUpdate = existingBook.First();
            //    bookToUpdate.AuthorId = request.AuthorId;
            //    bookToUpdate.CategoryId = request.CategoryId;
            //    bookToUpdate.Description = request.Description;
            //    bookToUpdate.Language = request.Language;
            //    bookToUpdate.PublisherId = request.PublisherId;
            //    bookToUpdate.Title = request.Title;

            //    await _repository.UpdateAsync(bookToUpdate); // Güncelleme işlemi
            //}
            //else
            //{
            //    // Kitap bulunamazsa bir hata fırlatabilirsiniz
            //    throw new Exception("Book not found");
            //}





            //var value=await _repository.GetByIdAsync(request.BookId);
            //value.AuthorId = request.AuthorId;
            //value.PublisherId = request.PublisherId;
            //value.AvailableCopies = request.AvailableCopies;
            //value.TotalCopies= request.TotalCopies;
            //value.
        }
    }
}
