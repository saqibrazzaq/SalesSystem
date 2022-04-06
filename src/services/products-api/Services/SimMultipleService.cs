using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class SimMultipleService : ISimMultipleService
    {
        private readonly ISimMultipleRepository _repo;
        private readonly ILogger<SimMultipleService> _logger;

        public SimMultipleService(ISimMultipleRepository simMultipleRepo, 
            ILogger<SimMultipleService> logger)
        {
            _repo = simMultipleRepo;
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
                response = response.GetFailureResponse("SimMultiple count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<SimMultipleDto>> Add(SimMultipleCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<SimMultipleDto>();

            try
            {
                // Create model from dto
                var simMultiple = new SimMultiple { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(simMultiple);
                _repo.Save();

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

        public async Task<ServiceResponse<bool>> Remove(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get SimMultiple
                var simMultiple = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (simMultiple == null) 
                {
                    response = response.GetFailureResponse("SimMultiple not found.");
                }
                else
                {
                    // SimMultiple found, delete it
                    _repo.Remove(simMultiple);
                    _repo.Save();
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

        public async Task<ServiceResponse<SimMultipleDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<SimMultipleDto>();

            try
            {
                // Get all SimMultiple
                var simMultiple = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (simMultiple == null) response = response.GetFailureResponse("Sim size not found.");
                else response.Data = simMultiple.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<SimMultipleDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<SimMultipleDto>>();

            try
            {
                // Get all SimMultiple
                var simMultiples = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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

        public async Task<ServiceResponse<SimMultipleDto>> Update(
            Guid id, SimMultipleUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<SimMultipleDto>();

            try
            {
                // Get SimMultiple
                var simMultiple = _repo.GetAll(
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
                    _repo.Update(simMultiple);
                    _repo.Save();
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
