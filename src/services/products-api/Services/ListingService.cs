using products_api.Data.Repository;
using products_api.Dtos;

namespace products_api.Services
{
    public class ListingService
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IAvailabilityRepository _availabilityRepo;
        private readonly INetworkRepository _networkRepo;
        private readonly INetworkBandRepository _networkBandRepo;
        private readonly ISimSizeRepository _simSizeRepo;
        private readonly ISimMultipleRepository _simMultipleRepo;
        private readonly IBodyFormFactorRepository _bodyFormFactorRepo;
        private readonly ILogger<ListingService> _logger;

        public ListingService(IBrandRepository brandRepo,
            IAvailabilityRepository availabilityRepo,
            INetworkRepository networkRepo,
            INetworkBandRepository networkBandRepo,
            ISimSizeRepository simSizeRepo,
            ISimMultipleRepository simMultipleRepo,
            IBodyFormFactorRepository bodyFormFactorRepo, 
            ILogger<ListingService> logger)
        {
            _brandRepo = brandRepo;
            _availabilityRepo = availabilityRepo;
            _networkRepo = networkRepo;
            _networkBandRepo = networkBandRepo;
            _simSizeRepo = simSizeRepo;
            _simMultipleRepo = simMultipleRepo;
            _bodyFormFactorRepo = bodyFormFactorRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<BrandDto>>> GetBrands()
        {
            // Create new response
            var response = new ServiceResponse<List<BrandDto>>();

            try
            {
                // Get all brands
                var brands = _brandRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var brandDtos = new List<BrandDto>();
                foreach (var brand in brands)
                {
                    brandDtos.Add(brand.AsDto());
                }
                // Set response
                response.Data = brandDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<AvailabilityDto>>> GetAvailabilities()
        {
            // Create new response
            var response = new ServiceResponse<List<AvailabilityDto>>();

            try
            {
                // Get all availabilities
                var availabilities = _availabilityRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var availabilityDtos = new List<AvailabilityDto>();
                foreach (var availability in availabilities)
                {
                    availabilityDtos.Add(availability.AsDto());
                }
                // Set response
                response.Data = availabilityDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<NetworkDto>>> GetNetworks()
        {
            // Create new response
            var response = new ServiceResponse<List<NetworkDto>>();

            try
            {
                // Get all Networks
                var networks = _networkRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var networkDtos = new List<NetworkDto>();
                foreach (var network in networks)
                {
                    networkDtos.Add(network.AsDto());
                }
                // Set response
                response.Data = networkDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<NetworkBandDto>>> GetNetworkBands(string networkName)
        {
            // Create new response
            var response = new ServiceResponse<List<NetworkBandDto>>();

            try
            {
                // Get network id from name
                var networkId = _networkRepo.GetAll(
                    filter: x => x.Name == networkName
                    ).Select(x => x.Id)
                    .FirstOrDefault();

                // Get all Networks bands
                var networkBands = _networkBandRepo.GetAll(
                    filter: x => x.NetworkId == networkId,
                    orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var networkBandDtos = new List<NetworkBandDto>();
                foreach (var networkBand in networkBands)
                {
                    networkBandDtos.Add(networkBand.AsDto());
                }
                // Set response
                response.Data = networkBandDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Networks bands service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<SimSizeDto>>> GetSimSizes()
        {
            // Create new response
            var response = new ServiceResponse<List<SimSizeDto>>();

            try
            {
                // Get all SimSize
                var simSizes = _simSizeRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var simSizeDtos = new List<SimSizeDto>();
                foreach (var simSize in simSizes)
                {
                    simSizeDtos.Add(simSize.AsDto());
                }
                // Set response
                response.Data = simSizeDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Sim size service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<SimMultipleDto>>> GetSimMultiples()
        {
            // Create new response
            var response = new ServiceResponse<List<SimMultipleDto>>();

            try
            {
                // Get all SimMultiple
                var simMultiples = _simMultipleRepo.GetAll(
                    orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var simMultipleDtos = new List<SimMultipleDto>();
                foreach (var simMultiple in simMultiples)
                {
                    simMultipleDtos.Add(simMultiple.AsDto());
                }
                // Set response
                response.Data = simMultipleDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple service failed.");
            }
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BodyFormFactorDto>>> GetBodyFormFactors()
        {
            // Create new response
            var response = new ServiceResponse<List<BodyFormFactorDto>>();

            try
            {
                // Get all BodyFormFactor
                var bodyFormFactors = _bodyFormFactorRepo.GetAll(
                    orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var bodyFormFactorDtos = new List<BodyFormFactorDto>();
                foreach (var bodyFormFactor in bodyFormFactors)
                {
                    bodyFormFactorDtos.Add(bodyFormFactor.AsDto());
                }
                // Set response
                response.Data = bodyFormFactorDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Body Form factor service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
