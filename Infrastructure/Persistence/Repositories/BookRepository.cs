using Application.Interfaces.BookInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Book>> GetTopBorrowedBooksAsync()
        {
            var books=await _context.Books
                .Include(x=>x.Author)
                .Include(x=>x.Category)
                .Include(x=>x.Publisher)
                .Include(x=>x.Barrows)
                .OrderByDescending(x=>x.Barrows.Count())
                .Take(5)
                .ToListAsync();
            return books;
        }
    }
}
