using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly TodoContext _context;

        public GenericRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool asNotTracking = false)
        {
            if (asNotTracking)
            {
                return filter != null ? await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync() :  await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            else
            {
                return filter != null ? await _context.Set<T>().Where(filter).ToListAsync() : await _context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetAsycn(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
