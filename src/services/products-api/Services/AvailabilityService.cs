using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepo;
        private readonly ILogger<AvailabilityService> _logger;

        public AvailabilityService(IAvailabilityRepository availabilityRepo, 
            ILogger<AvailabilityService> logger)
        {
            _availabilityRepo = availabilityRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _availabilityRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<AvailabilityDto>> CreateAvailability(
            AvailabilityCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<AvailabilityDto>();

            try
            {
                // Create model from dto
                var availability = new Availability { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _availabilityRepo.Add(availability);
                _availabilityRepo.Save();

                // Set data
                response.Data = availability.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability create service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> DeleteAvailability(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get Availability
                var availability = _availabilityRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (availability == null) 
                {
                    response = response.GetFailureResponse("Availability not found.");
                }
                else
                {
                    // Availability found, delete it
                    _availabilityRepo.Remove(availability);
                    _availabilityRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<AvailabilityDto>>> GetAvailabilities(string? name = null)
        {
            // Create new response
            var response = new ServiceResponse<List<AvailabilityDto>>();

            try
            {
                // Get all Availability
                var availabilities = _availabilityRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Match name
                if (string.IsNullOrEmpty(name) == false)
                {
                    availabilities = availabilities
                        .Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }
                // Create Dtos
                var availabilityDtos = new List<AvailabilityDto>();
                foreach (var availability in availabilities)
                {
                    availabilityDtos.Add(availability.AsDto());
                }
                // Set data
                response.Data = availabilityDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<AvailabilityDto>> UpdateAvailability(
            Guid id, AvailabilityUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<AvailabilityDto>();

            try
            {
                // Get Availability
                var availability = _availabilityRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (availability == null)
                {
                    response = response.GetFailureResponse("Availability not found.");
                }
                else
                {
                    // Availability found, update it
                    availability.Name = dto.Name;
                    availability.Position = dto.Position;
                    
                    // Save in repository
                    _availabilityRepo.Update(availability);
                    _availabilityRepo.Save();
                    // Set data
                    response.Data = availability.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
