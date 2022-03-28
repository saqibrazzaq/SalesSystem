using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Misc;

namespace products_api.Services
{
    public class NetworkService
    {
        private readonly INetworkRepository _networkRepository;
        private readonly ILogger<NetworkService> _logger;

        public NetworkService(INetworkRepository networkRepository,
            ILogger<NetworkService> logger)
        {
            _networkRepository = networkRepository;
            _logger = logger;
        }

        public async Task<ServiceResponse<NetworkSearchResult>> SearchNetworks(
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
                var searchResult = await _networkRepository.SearchNetworks(
                    text, page, pageSize, sortBy, sortDirection
                    );
                // Create response
                var response = new ServiceResponse<NetworkSearchResult>()
                {
                    Data = searchResult,
                    Success = true,
                    Message = "Network search successfull"
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<NetworkSearchResult>()
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to get Network from repository."
                };
            }
        }
    }
}
