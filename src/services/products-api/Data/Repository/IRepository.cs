using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace products_api.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(T[] entities);
        int DeleteAll();
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool isTracking = true
            );
        int Count(Expression<Func<T, bool>>? filter = null);
        void Save();
    }
}
