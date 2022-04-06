using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _repo;
        private readonly ILogger<AvailabilityService> _logger;

        public AvailabilityService(IAvailabilityRepository availabilityRepo, 
            ILogger<AvailabilityService> logger)
        {
            _repo = availabilityRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _repo.Count();
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

        public async Task<ServiceResponse<AvailabilityDto>> Add(
            AvailabilityCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<AvailabilityDto>();

            try
            {
                // Create model from dto
                var availability = new Availability { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(availability);
                _repo.Save();

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

        public async Task<ServiceResponse<bool>> Remove(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get Availability
                var availability = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (availability == null) 
                {
                    response = response.GetFailureResponse("Availability not found.");
                }
                else
                {
                    // Availability found, delete it
                    _repo.Remove(availability);
                    _repo.Save();
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

        public async Task<ServiceResponse<AvailabilityDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<AvailabilityDto>();

            try
            {
                // Get Availability
                var availability = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (availability == null) response = response.GetFailureResponse("Availability not found");
                else response.Data = availability.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<AvailabilityDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<AvailabilityDto>>();

            try
            {
                // Get all Availability
                var availabilities = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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

        public async Task<ServiceResponse<AvailabilityDto>> Update(
            Guid id, AvailabilityUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<AvailabilityDto>();

            try
            {
                // Get Availability
                var availability = _repo.GetAll(
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
                    _repo.Update(availability);
                    _repo.Save();
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

        public async Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            try
            {
                // Get all entities by id in the list
                var entities = _repo.GetAll(
                    filter: x => ids.Contains(x.Id)
                    ).ToArray();
                _repo.RemoveRange(entities);

                // Set data
                response.Data = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<int>> DeleteAll()
        {
            // Create new response
            var response = new ServiceResponse<int>();

            try
            {
                response.Data = _repo.DeleteAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
