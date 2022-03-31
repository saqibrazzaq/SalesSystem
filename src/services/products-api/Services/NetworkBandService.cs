using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class NetworkBandService : INetworkBandService
    {
        private readonly INetworkBandRepository _networkBandRepo;
        private readonly ILogger<NetworkBandService> _logger;
        private readonly INetworkService _networkService;

        public NetworkBandService(INetworkBandRepository networkBandRepo,
            ILogger<NetworkBandService> logger, 
            INetworkService networkService)
        {
            _networkBandRepo = networkBandRepo;
            _logger = logger;
            _networkService = networkService;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _networkBandRepo.Count();
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

        public async Task<ServiceResponse<NetworkBandDto>> CreateNetworkBand(NetworkBandCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<NetworkBandDto>();

            try
            {
                // Get parent network's id for which this band is created
                var networkServiceRes = await _networkService.GetNetworks(dto.NetworkName);
                // If network not found, throw exception
                if (networkServiceRes.Success == false || networkServiceRes.Data == null || 
                    networkServiceRes.Data.Count() == 0)
                {
                    throw new Exception("Network not found");
                }

                // Get network's id
                var networkId = networkServiceRes.Data.FirstOrDefault().Id;

                // Create model from dto
                var networkBand = new NetworkBand 
                { 
                    Name = dto.Name, Position = dto.Position, NetworkId = networkId 
                };

                // Add in repository
                _networkBandRepo.Add(networkBand);
                _networkBandRepo.Save();

                // Set data
                response.Data = networkBand.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band create service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> DeleteNetworkBand(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get Network Band
                var networkBand = _networkBandRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (networkBand == null) 
                {
                    response = response.GetFailureResponse("Network Band not found.");
                }
                else
                {
                    // Network Band found, delete it
                    _networkBandRepo.Remove(networkBand);
                    _networkBandRepo.Save();
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

        public async Task<ServiceResponse<List<NetworkBandDto>>> GetNetworkBands(string? name = null)
        {
            // Create new response
            var response = new ServiceResponse<List<NetworkBandDto>>();

            try
            {
                // Get network id (parent)
                var networkRes = await _networkService.GetNetworks(name);
                if (networkRes.Success == false || networkRes.Data == null ||
                    networkRes.Data.Count() == 0)
                {
                    throw new Exception("Network not found.");
                }

                // Network found, get its id
                var networkId = networkRes.Data.FirstOrDefault().Id;

                // Get all Network Band
                var networkBands = _networkBandRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Match name
                if (string.IsNullOrEmpty(name) == false)
                {
                    networkBands = networkBands.Where(x => x.NetworkId == networkId);
                }
                // Create Dtos
                var networkBandDtos = new List<NetworkBandDto>();
                foreach (var networkBand in networkBands)
                {
                    networkBandDtos.Add(networkBand.AsDto());
                }
                // Set data
                response.Data = networkBandDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<NetworkBandDto>> UpdateNetworkBand(
            Guid id, NetworkBandUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<NetworkBandDto>();

            try
            {
                // Get Network Band
                var networkBand = _networkBandRepo.GetAll(
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
                    _networkBandRepo.Update(networkBand);
                    _networkBandRepo.Save();
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
    }
}
