using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.BookInterface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetTopBorrowedBooksAsync();
        Task<List<Book>> HepsiniTopla();
        Task<List<Book>> GetAllBooksWithParametres(Expression<Func<Book, bool>> expression);
        Task<Book> GetBookById(int id);
    }
}
