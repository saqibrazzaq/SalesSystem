using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class DisplayTechnologyService : IDisplayTechnologyService
    {
        private readonly IDisplayTechnologyRepository _displayTechnologyRepo;
        private readonly ILogger<DisplayTechnologyService> _logger;

        public DisplayTechnologyService(IDisplayTechnologyRepository displayTechnologyRepo, 
            ILogger<DisplayTechnologyService> logger)
        {
            _displayTechnologyRepo = displayTechnologyRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _displayTechnologyRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("DisplayTechnology count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<DisplayTechnologyDto>> Add(DisplayTechnologyCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<DisplayTechnologyDto>();

            try
            {
                // Create model from dto
                var displayTechnology = new DisplayTechnology { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _displayTechnologyRepo.Add(displayTechnology);
                _displayTechnologyRepo.Save();

                // Set data
                response.Data = displayTechnology.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("DisplayTechnology create service failed.");
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
                // Get DisplayTechnology
                var displayTechnology = _displayTechnologyRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (displayTechnology == null) 
                {
                    response = response.GetFailureResponse("DisplayTechnology not found.");
                }
                else
                {
                    // DisplayTechnology found, delete it
                    _displayTechnologyRepo.Remove(displayTechnology);
                    _displayTechnologyRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("DisplayTechnology delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<DisplayTechnologyDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<DisplayTechnologyDto>();

            try
            {
                // Get all DisplayTechnology
                var displayTechnology = _displayTechnologyRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (displayTechnology == null) response = response.GetFailureResponse("DisplayTechnology not found");
                else response.Data = displayTechnology.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("DisplayTechnology service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<DisplayTechnologyDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<DisplayTechnologyDto>>();

            try
            {
                // Get all DisplayTechnology
                var displayTechnologies = _displayTechnologyRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var displayTechnologyDtos = new List<DisplayTechnologyDto>();
                foreach (var displayTechnology in displayTechnologies)
                {
                    displayTechnologyDtos.Add(displayTechnology.AsDto());
                }
                // Set data
                response.Data = displayTechnologyDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("DisplayTechnology service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<DisplayTechnologyDto>> Update(Guid id, DisplayTechnologyUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<DisplayTechnologyDto>();

            try
            {
                // Get DisplayTechnology
                var displayTechnology = _displayTechnologyRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (displayTechnology == null)
                {
                    response = response.GetFailureResponse("DisplayTechnology not found.");
                }
                else
                {
                    // DisplayTechnology found, update it
                    displayTechnology.Name = dto.Name;
                    displayTechnology.Position = dto.Position;
                    
                    // Save in repository
                    _displayTechnologyRepo.Update(displayTechnology);
                    _displayTechnologyRepo.Save();
                    // Set data
                    response.Data = displayTechnology.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("DisplayTechnology update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
