using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class SimSizeService : ISimSizeService
    {
        private readonly ISimSizeRepository _repo;
        private readonly ILogger<SimSizeService> _logger;

        public SimSizeService(ISimSizeRepository simSizeRepo, 
            ILogger<SimSizeService> logger)
        {
            _repo = simSizeRepo;
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
                _repo.Add(simSize);
                _repo.Save();

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
                var brand = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (brand == null) 
                {
                    response = response.GetFailureResponse("SimSize not found.");
                }
                else
                {
                    // SimSize found, delete it
                    _repo.Remove(brand);
                    _repo.Save();
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
                var simSize = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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
                var simSizes = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var simSize = _repo.GetAll(
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
                    _repo.Update(simSize);
                    _repo.Save();
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
            catch (Exception ex)
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
