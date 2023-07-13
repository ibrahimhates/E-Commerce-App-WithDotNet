using System.Linq.Expressions;

namespace Repository.Repositories.Abstracts
{
    public interface IGenericRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T,bool>> expression,bool trackChanges);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
