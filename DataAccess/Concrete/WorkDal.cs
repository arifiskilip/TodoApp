using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class WorkDal : GenericRepository<Work> , IWorkDal
    {
        public WorkDal(TodoContext context) : base(context)
        {
        }
    }
}
