using products_api.Data.Repository;
using products_api.Dtos;

namespace products_api.Services
{
    public class ListingService
    {
        private readonly ILogger<ListingService> _logger;

        public ListingService(
            IBodyFormFactorRepository bodyFormFactorRepo, 
            ILogger<ListingService> logger)
        {
            _logger = logger;
        }

        

        

        

        
    }
}
