using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerCameraTypeRepository : SqlServerRepository<CameraType>, ICameraTypeRepository
    {
        public SqlServerCameraTypeRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        
    }
}
