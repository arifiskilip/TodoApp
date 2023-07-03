using DataAccess.Abstract;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUoW<T> where T : class, new()
    {
        IGenericRepository<T> GetRepository();
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
