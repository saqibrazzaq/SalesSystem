using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using products_api.Data.Repository;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerRepository<T> : IRepository<T> where T : class
    {
        // For ef core
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        // For Dapper
        private readonly IConfiguration _configuration;
        public SqlServerRepository(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            dbSet = _db.Set<T>();

            _configuration = configuration;
        }

        public SqlConnection SqlConnection
        {
            get
            {
                return new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public int Count(Expression<Func<T, bool>>? filter = null)
        {
            // Get query
            IQueryable<T> query = dbSet;

            // Apply filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool isTracking = true)
        {
            // Get query
            IQueryable<T> query = dbSet;

            // Apply filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            // Order by
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Tracking
            if (isTracking == false)
                query.AsNoTracking();

            return query.AsEnumerable();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
