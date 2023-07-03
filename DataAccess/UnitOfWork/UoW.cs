using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UoW<T> : IUoW<T> where T : class, new()
    {
        private readonly TodoContext _context;

        public UoW(TodoContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository()
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
