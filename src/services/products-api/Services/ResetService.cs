using products_api.Data.Repository;

namespace products_api.Services
{
    public class ResetService
    {
        private readonly ILogger<ResetService> _logger;
        private readonly IResetRepository _resetRepository;

        public ResetService(ILogger<ResetService> logger,
            IResetRepository resetRepository)
        {
            _logger = logger;
            _resetRepository = resetRepository;
        }

        public async Task<ServiceResponse<string>> ResetData()
        {
            // Call service
            try
            {
                // Get result
                var result = await _resetRepository.ResetData();
                // Create response
                var response = new ServiceResponse<string>()
                {
                    Data = result,
                    Success = true,
                    Message = "Data reset done successfully."
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<string>()
                {
                    Data = null,
                    Success = false,
                    Message = "Reset service failed."
                };
            }
        }
    }
}
