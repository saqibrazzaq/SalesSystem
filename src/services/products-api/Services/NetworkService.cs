using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class NetworkService : INetworkService
    {
        private readonly INetworkRepository _repo;
        private readonly ILogger<NetworkService> _logger;

        public NetworkService(INetworkRepository networkRepo, 
            ILogger<NetworkService> logger)
        {
            _repo = networkRepo;
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
                _repo.Add(network);
                _repo.Save();

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
                var brand = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (brand == null) 
                {
                    response = response.GetFailureResponse("Network not found.");
                }
                else
                {
                    // Network found, delete it
                    _repo.Remove(brand);
                    _repo.Save();
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
                var network = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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

        public async Task<ServiceResponse<NetworkDto>> GetByName(string name)
        {
            // Create new response
            var response = new ServiceResponse<NetworkDto>();

            try
            {
                // Get Network
                var network = _repo.GetAll()
                    .Where(x => x.Name == name)
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
                var networks = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var network = _repo.GetAll(
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
                    _repo.Update(network);
                    _repo.Save();
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
