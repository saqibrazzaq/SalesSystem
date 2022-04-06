using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class RemovableBatteryService : IRemovableBatteryService
    {
        private readonly IRemovableBatteryRepository _repo;
        private readonly ILogger<RemovableBatteryService> _logger;

        public RemovableBatteryService(IRemovableBatteryRepository removableBatteryRepo, 
            ILogger<RemovableBatteryService> logger)
        {
            _repo = removableBatteryRepo;
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
                response = response.GetFailureResponse("RemovableBattery count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<RemovableBatteryDto>> Add(
            RemovableBatteryCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<RemovableBatteryDto>();

            try
            {
                // Create model from dto
                var removableBattery = new RemovableBattery { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(removableBattery);
                _repo.Save();

                // Set data
                response.Data = removableBattery.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("RemovableBattery create service failed.");
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
                // Get RemovableBattery
                var removableBattery = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (removableBattery == null) 
                {
                    response = response.GetFailureResponse("RemovableBattery not found.");
                }
                else
                {
                    // RemovableBattery found, delete it
                    _repo.Remove(removableBattery);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("RemovableBattery delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<RemovableBatteryDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<RemovableBatteryDto>();

            try
            {
                // Get RemovableBattery
                var removableBattery = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (removableBattery == null) response = response.GetFailureResponse("RemovableBattery not found");
                else response.Data = removableBattery.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("RemovableBattery service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<RemovableBatteryDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<RemovableBatteryDto>>();

            try
            {
                // Get all RemovableBattery
                var removableBatteries = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var removableBatteryDtos = new List<RemovableBatteryDto>();
                foreach (var removableBattery in removableBatteries)
                {
                    removableBatteryDtos.Add(removableBattery.AsDto());
                }
                // Set data
                response.Data = removableBatteryDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("RemovableBattery service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<RemovableBatteryDto>> Update(
            Guid id, RemovableBatteryUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<RemovableBatteryDto>();

            try
            {
                // Get RemovableBattery
                var removableBattery = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (removableBattery == null)
                {
                    response = response.GetFailureResponse("RemovableBattery not found.");
                }
                else
                {
                    // RemovableBattery found, update it
                    removableBattery.Name = dto.Name;
                    removableBattery.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(removableBattery);
                    _repo.Save();
                    // Set data
                    response.Data = removableBattery.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("RemovableBattery update service failed.");
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
