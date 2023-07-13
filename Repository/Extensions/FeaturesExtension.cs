using Entity.Models;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class FeaturesExtension
    {
        public static IQueryable<T> ToPageList<T>(this IQueryable<T> query,
            int pageNumber,int pageSize) where T : class
        {
            var pagedQuery = query
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize);
            return pagedQuery;
        }

        public static IQueryable<T> Search<T,TKey>(this IQueryable<T> query,
            Func<T, TKey> propertySelector,
            string searchTerm) where T : class
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return query;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return query
                .Where(b => propertySelector(b)
                .ToString()
                .ToLower()
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> query,
            string orderBy) 
        {
            if (string.IsNullOrEmpty(orderBy))
                return query;

           
            var orderByQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderBy);

            if (orderByQuery is null)
                return query;

            return query.OrderBy(orderByQuery);
        }
    }
}
