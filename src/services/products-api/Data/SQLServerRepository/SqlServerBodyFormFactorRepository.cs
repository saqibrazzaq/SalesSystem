using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerBodyFormFactorRepository : 
        SqlServerRepository<BodyFormFactor>, IBodyFormFactorRepository
    {
        public SqlServerBodyFormFactorRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        
    }
}
