using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class SimSizeService : ISimSizeService
    {
        private readonly ISimSizeRepository _simSizeRepo;
        private readonly ILogger<SimSizeService> _logger;

        public SimSizeService(ISimSizeRepository simSizeRepo, 
            ILogger<SimSizeService> logger)
        {
            _simSizeRepo = simSizeRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _simSizeRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<SimSizeDto>> Add(SimSizeCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<SimSizeDto>();

            try
            {
                // Create model from dto
                var simSize = new SimSize { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _simSizeRepo.Add(simSize);
                _simSizeRepo.Save();

                // Set data
                response.Data = simSize.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize create service failed.");
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
                // Get SimSize
                var brand = _simSizeRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (brand == null) 
                {
                    response = response.GetFailureResponse("SimSize not found.");
                }
                else
                {
                    // SimSize found, delete it
                    _simSizeRepo.Remove(brand);
                    _simSizeRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<SimSizeDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<SimSizeDto>();

            try
            {
                // Get all SimSize
                var simSize = _simSizeRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (simSize == null) response = response.GetFailureResponse("Sim size not found.");
                else response.Data = simSize.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<SimSizeDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<SimSizeDto>>();

            try
            {
                // Get all SimSize
                var simSizes = _simSizeRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var simSizeDtos = new List<SimSizeDto>();
                foreach (var simSize in simSizes)
                {
                    simSizeDtos.Add(simSize.AsDto());
                }
                // Set data
                response.Data = simSizeDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<SimSizeDto>> Update(Guid id, SimSizeUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<SimSizeDto>();

            try
            {
                // Get SimSize
                var simSize = _simSizeRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (simSize == null)
                {
                    response = response.GetFailureResponse("SimSize not found.");
                }
                else
                {
                    // SimSize found, update it
                    simSize.Name = dto.Name;
                    simSize.Position = dto.Position;
                    
                    // Save in repository
                    _simSizeRepo.Update(simSize);
                    _simSizeRepo.Save();
                    // Set data
                    response.Data = simSize.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
