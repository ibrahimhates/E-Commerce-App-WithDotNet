using System.Linq.Expressions;

namespace Repository.Repositories.Abstracts
{
    public interface IGenericRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T,bool>> expression,bool trackChanges);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
