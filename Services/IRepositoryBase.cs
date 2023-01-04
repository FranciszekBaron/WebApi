using System.Linq.Expressions;

namespace WebApplication1.Services
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);

        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
