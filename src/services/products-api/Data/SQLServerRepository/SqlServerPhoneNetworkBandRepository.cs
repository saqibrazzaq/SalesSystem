using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerPhoneNetworkBandRepository : 
        SqlServerRepository<PhoneNetworkBand>, IPhoneNetworkBandRepository
    {
        public SqlServerPhoneNetworkBandRepository(AppDbContext db, IConfiguration configuration)
            : base(db, configuration)
        {
            
        }

        
    }
}
