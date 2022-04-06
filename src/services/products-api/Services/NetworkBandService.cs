using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class NetworkBandService : INetworkBandService
    {
        private readonly INetworkBandRepository _repo;
        private readonly ILogger<NetworkBandService> _logger;
        private readonly INetworkService _networkService;

        public NetworkBandService(INetworkBandRepository networkBandRepo,
            ILogger<NetworkBandService> logger, 
            INetworkService networkService)
        {
            _repo = networkBandRepo;
            _logger = logger;
            _networkService = networkService;
        }

        public async Task<ServiceResponse<int>> Count(Guid networkId)
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count for network id
                var count = _repo.Count(filter: x => x.NetworkId == networkId);
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkBandDto>> Add(NetworkBandCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<NetworkBandDto>();

            try
            {
                // Get parent network's id for which this band is created
                var networkServiceRes = await _networkService.Get(dto.NetworkId);
                // If network not found, throw exception
                if (networkServiceRes.Success == false)
                {
                    response = response.GetFailureResponse("Network not found.");
                }
                else
                {
                    // Create model from dto
                    var networkBand = new NetworkBand
                    {
                        Name = dto.Name,
                        Position = dto.Position,
                        NetworkId = dto.NetworkId
                    };

                    // Add in repository
                    _repo.Add(networkBand);
                    _repo.Save();

                    // Set data
                    response.Data = networkBand.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band create service failed.");
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
                // Get Network Band
                var networkBand = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (networkBand == null) 
                {
                    response = response.GetFailureResponse("Network Band not found.");
                }
                else
                {
                    // Network Band found, delete it
                    _repo.Remove(networkBand);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkBandDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<NetworkBandDto>();

            try
            {
                // Get all Network Bands
                var networkBand = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (networkBand == null) response = response.GetFailureResponse("Network band not found");
                else response.Data = networkBand.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<NetworkBandDto>>> GetAll(Guid networkId)
        {
            // Create new response
            var response = new ServiceResponse<List<NetworkBandDto>>();

            try
            {
                // Get all Network Band
                var networkBands = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.NetworkId == networkId);
                // Create Dtos
                var networkBandDtos = new List<NetworkBandDto>();
                foreach (var networkBand in networkBands)
                {
                    networkBandDtos.Add(networkBand.AsDto());
                }
                // Check for not found
                if (networkBandDtos.Count == 0) response = response.GetFailureResponse("Network not found.");
                else response.Data = networkBandDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkBandDto>> Update(
            Guid id, NetworkBandUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<NetworkBandDto>();

            try
            {
                // Get Network Band
                var networkBand = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (networkBand == null)
                {
                    response = response.GetFailureResponse("Network Band not found.");
                }
                else
                {
                    // Network Band found, update it
                    networkBand.Name = dto.Name;
                    networkBand.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(networkBand);
                    _repo.Save();
                    // Set data
                    response.Data = networkBand.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band update service failed.");
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
