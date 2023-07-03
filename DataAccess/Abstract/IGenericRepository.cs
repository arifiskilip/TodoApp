using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class,new()
    {
        Task AddAsync(T entity);
        Task<T> GetAsycn(object id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool asNotTracking = false);
        IQueryable<T> GetQuery();
        void Update(T entity);
        void Delete(T entity);

    }
}
