using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerSimMultipleRepository : SqlServerRepository<SimMultiple>, ISimMultipleRepository
    {
        public SqlServerSimMultipleRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        
    }
}
