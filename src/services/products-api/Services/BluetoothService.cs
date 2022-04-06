using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class BluetoothService : IBluetoothService
    {
        private readonly IBluetoothRepository _repo;
        private readonly ILogger<BluetoothService> _logger;

        public BluetoothService(IBluetoothRepository bluetoothRepo, 
            ILogger<BluetoothService> logger)
        {
            _repo = bluetoothRepo;
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
                response = response.GetFailureResponse("Bluetooth count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BluetoothDto>> Add(BluetoothCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BluetoothDto>();

            try
            {
                // Create model from dto
                var bluetooth = new Bluetooth { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(bluetooth);
                _repo.Save();

                // Set data
                response.Data = bluetooth.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Bluetooth create service failed.");
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
                // Get Bluetooth
                var bluetooth = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bluetooth == null) 
                {
                    response = response.GetFailureResponse("Bluetooth not found.");
                }
                else
                {
                    // Bluetooth found, delete it
                    _repo.Remove(bluetooth);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Bluetooth delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BluetoothDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<BluetoothDto>();

            try
            {
                // Get all Bluetooth
                var wifi = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (wifi == null) response = response.GetFailureResponse("Bluetooth not found");
                else response.Data = wifi.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Bluetooth service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BluetoothDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<BluetoothDto>>();

            try
            {
                // Get all Bluetooth
                var bluetooths = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var bluetoothDtos = new List<BluetoothDto>();
                foreach (var bluetooth in bluetooths)
                {
                    bluetoothDtos.Add(bluetooth.AsDto());
                }
                // Set data
                response.Data = bluetoothDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Bluetooth service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BluetoothDto>> Update(Guid id, BluetoothUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BluetoothDto>();

            try
            {
                // Get Bluetooth
                var bluetooth = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bluetooth == null)
                {
                    response = response.GetFailureResponse("Bluetooth not found.");
                }
                else
                {
                    // Bluetooth found, update it
                    bluetooth.Name = dto.Name;
                    bluetooth.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(bluetooth);
                    _repo.Save();
                    // Set data
                    response.Data = bluetooth.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Bluetooth update service failed.");
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
