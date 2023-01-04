using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {


        private readonly OrganDbContext _dbContext;

        public RepositoryBase(OrganDbContext dbContext) { 
        _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return _dbContext.Set<T>().Where(condition).AsNoTracking();
        }

        
    }
}
