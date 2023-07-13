using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Concretes
{
    public class GenericRepositoryBase<T> : IGenericRepositoryBase<T> where T : class
    {
        private readonly ETContext _context;
        public GenericRepositoryBase(ETContext context)
        {
            _context=context;
        }

        public IQueryable<T> GetAll(bool trackChanges) => 
            trackChanges?
            _context.Set<T>().AsTracking():
            _context.Set<T>().AsNoTracking();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ?
            _context.Set<T>().Where(expression).AsTracking():
            _context.Set<T>().Where(expression).AsNoTracking();

        public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity);        

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => 
            _context.Set<T>().AnyAsync(expression);

        public Task<int> CountAsync(Expression<Func<T, bool>> expression) => 
            _context.Set<T>().CountAsync(expression);

    }
}
