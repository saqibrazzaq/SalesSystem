using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class SimMultipleService : ISimMultipleService
    {
        private readonly ISimMultipleRepository _simMultipleRepo;
        private readonly ILogger<SimMultipleService> _logger;

        public SimMultipleService(ISimMultipleRepository simMultipleRepo, 
            ILogger<SimMultipleService> logger)
        {
            _simMultipleRepo = simMultipleRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _simMultipleRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<SimMultipleDto>> CreateSimMultiple(SimMultipleCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<SimMultipleDto>();

            try
            {
                // Create model from dto
                var simMultiple = new SimMultiple { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _simMultipleRepo.Add(simMultiple);
                _simMultipleRepo.Save();

                // Set data
                response.Data = simMultiple.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple create service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> DeleteSimMultiple(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get SimMultiple
                var simMultiple = _simMultipleRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (simMultiple == null) 
                {
                    response = response.GetFailureResponse("SimMultiple not found.");
                }
                else
                {
                    // SimMultiple found, delete it
                    _simMultipleRepo.Remove(simMultiple);
                    _simMultipleRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<SimMultipleDto>>> GetSimMultiples(string? name = null)
        {
            // Create new response
            var response = new ServiceResponse<List<SimMultipleDto>>();

            try
            {
                // Get all SimMultiple
                var simMultiples = _simMultipleRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Match name
                if (string.IsNullOrEmpty(name) == false)
                {
                    simMultiples = simMultiples.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }
                // Create Dtos
                var simMultipleDtos = new List<SimMultipleDto>();
                foreach (var simMultiple in simMultiples)
                {
                    simMultipleDtos.Add(simMultiple.AsDto());
                }
                // Set data
                response.Data = simMultipleDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<SimMultipleDto>> UpdateSimMultiple(
            Guid id, SimMultipleUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<SimMultipleDto>();

            try
            {
                // Get SimMultiple
                var simMultiple = _simMultipleRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (simMultiple == null)
                {
                    response = response.GetFailureResponse("SimMultiple not found.");
                }
                else
                {
                    // SimMultiple found, update it
                    simMultiple.Name = dto.Name;
                    simMultiple.Position = dto.Position;
                    
                    // Save in repository
                    _simMultipleRepo.Update(simMultiple);
                    _simMultipleRepo.Save();
                    // Set data
                    response.Data = simMultiple.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
