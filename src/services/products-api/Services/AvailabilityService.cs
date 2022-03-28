using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Misc;

namespace products_api.Services
{
    public class AvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly ILogger<AvailabilityService> _logger;

        public AvailabilityService(IAvailabilityRepository availabilityRepository,
            ILogger<AvailabilityService> logger)
        {
            _availabilityRepository = availabilityRepository;
            _logger = logger;
        }

        public async Task<ServiceResponse<AvailabilitySearchResult>> SearchAvailability(
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
                var searchResult = await _availabilityRepository.SearchAvailability(
                    text, page, pageSize, sortBy, sortDirection
                    );
                // Create response
                var response = new ServiceResponse<AvailabilitySearchResult>()
                {
                    Data = searchResult,
                    Success = true,
                    Message = "Availability search successfull"
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<AvailabilitySearchResult>()
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to get Availability from repository."
                };
            }
        }
    }
}
