using Application.Interfaces;
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
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly LibraryContext _context;

        public Repository(LibraryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .Where(x=>x.DeletedDate==null)
                .ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity!=null && entity.DeletedDate == null)
            {
                return entity;
            }
            return null;
        }

        public async Task RemoveAsync(T entity)
        {
            entity.DeletedDate= DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {

            var result = await _context.Set<T>()
                                 .Where(expression) // Belirtilen koşula göre filtreleme yapar
                                 .Where(e => e.DeletedDate == null) // Silinmiş olanları hariç tutar
                                 .ToListAsync(); // Verileri liste olarak getirir
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
    }
}
