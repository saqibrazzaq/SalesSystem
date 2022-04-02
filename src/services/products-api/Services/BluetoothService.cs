using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class BluetoothService : IBluetoothService
    {
        private readonly IBluetoothRepository _bluetoothRepo;
        private readonly ILogger<BluetoothService> _logger;

        public BluetoothService(IBluetoothRepository bluetoothRepo, 
            ILogger<BluetoothService> logger)
        {
            _bluetoothRepo = bluetoothRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _bluetoothRepo.Count();
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
                _bluetoothRepo.Add(bluetooth);
                _bluetoothRepo.Save();

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
                var bluetooth = _bluetoothRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bluetooth == null) 
                {
                    response = response.GetFailureResponse("Bluetooth not found.");
                }
                else
                {
                    // Bluetooth found, delete it
                    _bluetoothRepo.Remove(bluetooth);
                    _bluetoothRepo.Save();
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
                var wifi = _bluetoothRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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
                var bluetooths = _bluetoothRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var bluetooth = _bluetoothRepo.GetAll(
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
                    _bluetoothRepo.Update(bluetooth);
                    _bluetoothRepo.Save();
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
    }
}
