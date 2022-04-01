using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class NetworkService : INetworkService
    {
        private readonly INetworkRepository _networkRepo;
        private readonly ILogger<NetworkService> _logger;

        public NetworkService(INetworkRepository networkRepo, 
            ILogger<NetworkService> logger)
        {
            _networkRepo = networkRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _networkRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkDto>> Add(NetworkCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<NetworkDto>();

            try
            {
                // Create model from dto
                var network = new Network { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _networkRepo.Add(network);
                _networkRepo.Save();

                // Set data
                response.Data = network.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network create service failed.");
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
                // Get Network
                var brand = _networkRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (brand == null) 
                {
                    response = response.GetFailureResponse("Network not found.");
                }
                else
                {
                    // Network found, delete it
                    _networkRepo.Remove(brand);
                    _networkRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<NetworkDto>();

            try
            {
                // Get Network
                var network = _networkRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (network == null) response = response.GetFailureResponse("Network not found");
                else response.Data = network.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<NetworkDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<NetworkDto>>();

            try
            {
                // Get all Network
                var networks = _networkRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var networkDtos = new List<NetworkDto>();
                foreach (var network in networks)
                {
                    networkDtos.Add(network.AsDto());
                }
                // Set data
                response.Data = networkDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkDto>> Update(Guid id, NetworkUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<NetworkDto>();

            try
            {
                // Get Network
                var network = _networkRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (network == null)
                {
                    response = response.GetFailureResponse("Network not found.");
                }
                else
                {
                    // Network found, update it
                    network.Name = dto.Name;
                    network.Position = dto.Position;
                    
                    // Save in repository
                    _networkRepo.Update(network);
                    _networkRepo.Save();
                    // Set data
                    response.Data = network.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
