using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class BatteryTypeService : IBatteryTypeService
    {
        private readonly IBatteryTypeRepository _repo;
        private readonly ILogger<BatteryTypeService> _logger;

        public BatteryTypeService(IBatteryTypeRepository batteryTypeRepo, 
            ILogger<BatteryTypeService> logger)
        {
            _repo = batteryTypeRepo;
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
                response = response.GetFailureResponse("BatteryType count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BatteryTypeDto>> Add(
            BatteryTypeCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BatteryTypeDto>();

            try
            {
                // Create model from dto
                var removableBattery = new BatteryType { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(removableBattery);
                _repo.Save();

                // Set data
                response.Data = removableBattery.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BatteryType create service failed.");
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
                    response = response.GetFailureResponse("BatteryType not found.");
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
                response = response.GetFailureResponse("BatteryType delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BatteryTypeDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<BatteryTypeDto>();

            try
            {
                // Get RemovableBattery
                var removableBattery = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (removableBattery == null) response = response.GetFailureResponse("BatteryType not found");
                else response.Data = removableBattery.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BatteryType service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BatteryTypeDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<BatteryTypeDto>>();

            try
            {
                // Get all RemovableBattery
                var removableBatteries = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var removableBatteryDtos = new List<BatteryTypeDto>();
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
                response = response.GetFailureResponse("BatteryType service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BatteryTypeDto>> Update(
            Guid id, BatteryTypeUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BatteryTypeDto>();

            try
            {
                // Get RemovableBattery
                var removableBattery = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (removableBattery == null)
                {
                    response = response.GetFailureResponse("BatteryType not found.");
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
                response = response.GetFailureResponse("BatteryType update service failed.");
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
