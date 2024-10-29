using Application.Interfaces.BookInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksWithParametres(Expression<Func<Book, bool>> expression)
        {
            var result = await _context.Books
                   .Include(x => x.Author)
                   .Include(x => x.Category)
                   .Include(x => x.Publisher)
                   .Where(expression) // Dinamik olarak gelen koşul
                   .Where(e => e.DeletedDate == null) // Silinmiş olanları hariç tutar
                   .ToListAsync();
            return result;
        }

        public async Task<List<Book>> GetTopBorrowedBooksAsync()
        {
            var books = await _context.Books
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Publisher)
                .Include(x => x.Barrows)
                .OrderByDescending(x => x.Barrows.Count())
                .Take(5)
                .ToListAsync();
            return books;
        }

        public async Task<List<Book>> HepsiniTopla()
        {
            var values = await _context.Books
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Publisher)
                .ToListAsync();
            return values;
        }
    }
}
