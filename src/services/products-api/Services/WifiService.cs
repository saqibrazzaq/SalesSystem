using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class WifiService : IWifiService
    {
        private readonly IWifiRepository _wifiRepo;
        private readonly ILogger<WifiService> _logger;

        public WifiService(IWifiRepository wifiRepo, 
            ILogger<WifiService> logger)
        {
            _wifiRepo = wifiRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _wifiRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Wifi count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<WifiDto>> Add(WifiCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<WifiDto>();

            try
            {
                // Create model from dto
                var wifi = new Wifi { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _wifiRepo.Add(wifi);
                _wifiRepo.Save();

                // Set data
                response.Data = wifi.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Wifi create service failed.");
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
                // Get Wifi
                var wifi = _wifiRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (wifi == null) 
                {
                    response = response.GetFailureResponse("Wifi not found.");
                }
                else
                {
                    // Wifi found, delete it
                    _wifiRepo.Remove(wifi);
                    _wifiRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Wifi delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<WifiDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<WifiDto>();

            try
            {
                // Get all Wifi
                var wifi = _wifiRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (wifi == null) response = response.GetFailureResponse("Wifi not found");
                else response.Data = wifi.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Wifi service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<WifiDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<WifiDto>>();

            try
            {
                // Get all Wifi
                var wifis = _wifiRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var wifiDtos = new List<WifiDto>();
                foreach (var wifi in wifis)
                {
                    wifiDtos.Add(wifi.AsDto());
                }
                // Set data
                response.Data = wifiDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Wifi service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<WifiDto>> Update(Guid id, WifiUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<WifiDto>();

            try
            {
                // Get Wifi
                var wifi = _wifiRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (wifi == null)
                {
                    response = response.GetFailureResponse("Wifi not found.");
                }
                else
                {
                    // Wifi found, update it
                    wifi.Name = dto.Name;
                    wifi.Position = dto.Position;
                    
                    // Save in repository
                    _wifiRepo.Update(wifi);
                    _wifiRepo.Save();
                    // Set data
                    response.Data = wifi.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Wifi update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
