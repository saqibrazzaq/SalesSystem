using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Misc;

namespace products_api.Services
{
    public class BrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ILogger<BrandService> _logger;

        public BrandService(IBrandRepository brandRepository,
            ILogger<BrandService> logger)
        {
            _brandRepository = brandRepository;
            _logger = logger;
        }

        public async Task<ServiceResponse<BrandSearchResult>> SearchBrands(
            string? text = null,
            int? page = 1,
            int? pageSize = DefaultValues.PageSize,
            string? sortBy = "position",
            string? sortDirection = "asc"
            )
        {
            try
            {
                // Get Brand
                var searchResult = await _brandRepository.SearchBrands(
                    text, page, pageSize, sortBy, sortDirection
                    );
                // Create response
                var response = new ServiceResponse<BrandSearchResult>()
                {
                    Data = searchResult,
                    Success = true,
                    Message = "Brand search successfull"
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<BrandSearchResult>()
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to get Brand from repository."
                };
            }
        }
    }
}
