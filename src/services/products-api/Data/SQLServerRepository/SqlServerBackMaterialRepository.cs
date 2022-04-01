using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerBackMaterialRepository : 
        SqlServerRepository<BackMaterial>, IBackMaterialRepository
    {
        public SqlServerBackMaterialRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        
    }
}
