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

        public ListingService(IBrandRepository brandRepo,
            IAvailabilityRepository availabilityRepo,
            INetworkRepository networkRepo,
            INetworkBandRepository networkBandRepo,
            ISimSizeRepository simSizeRepo, 
            ISimMultipleRepository simMultipleRepo)
        {
            _brandRepo = brandRepo;
            _availabilityRepo = availabilityRepo;
            _networkRepo = networkRepo;
            _networkBandRepo = networkBandRepo;
            _simSizeRepo = simSizeRepo;
            _simMultipleRepo = simMultipleRepo;
        }

        public Task<List<BrandDto>> GetBrands()
        {
            // Get all brands
            var brands = _brandRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
            // Create Dtos
            var brandDtos = new List<BrandDto>();
            foreach (var brand in brands)
            {
                brandDtos.Add(brand.AsDto());
            }
            return Task.FromResult(brandDtos);
        }

        public Task<List<AvailabilityDto>> GetAvailabilities()
        {
            // Get all availabilities
            var availabilities = _availabilityRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
            // Create Dtos
            var availabilityDtos = new List<AvailabilityDto>();
            foreach (var availability in availabilities)
            {
                availabilityDtos.Add(availability.AsDto());
            }
            return Task.FromResult(availabilityDtos);
        }

        public Task<List<NetworkDto>> GetNetworks()
        {
            // Get all Networks
            var networks = _networkRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
            // Create Dtos
            var networkDtos = new List<NetworkDto>();
            foreach (var network in networks)
            {
                networkDtos.Add(network.AsDto());
            }
            return Task.FromResult(networkDtos);
        }

        public Task<List<NetworkBandDto>> GetNetworkBands(string networkName)
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
            return Task.FromResult(networkBandDtos);
        }

        public Task<List<SimSizeDto>> GetSimSizes()
        {
            // Get all SimSize
            var simSizes = _simSizeRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
            // Create Dtos
            var simSizeDtos = new List<SimSizeDto>();
            foreach (var simSize in simSizes)
            {
                simSizeDtos.Add(simSize.AsDto());
            }
            return Task.FromResult(simSizeDtos);
        }

        public Task<List<SimMultipleDto>> GetSimMultiples()
        {
            // Get all SimMultiple
            var simMultiples = _simMultipleRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
            // Create Dtos
            var simMultipleDtos = new List<SimMultipleDto>();
            foreach (var simMultiple in simMultiples)
            {
                simMultipleDtos.Add(simMultiple.AsDto());
            }
            return Task.FromResult(simMultipleDtos);
        }
    }
}
