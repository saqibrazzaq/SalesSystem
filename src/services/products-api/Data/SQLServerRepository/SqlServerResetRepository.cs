using Dapper;
using products_api.Data.Repository;
using products_api.Models;
using products_api.SeedData.SeedModels;
using System.Data.SqlClient;
using System.Text.Json;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerResetRepository : IResetRepository
    {
        private readonly string _dataFolderName = "SeedData";
        private readonly string categoriesFile = "default-categories.json";
        private readonly string brandsFile = "default-brands.json";
        private readonly string availabilityFile = "default-availability.json";
        private readonly string networkFile = "default-networks.json";
        private readonly string networkDetailsFile = "default-network-bands.json";
        private readonly string simSizeFile = "default-sim-size.json";
        private readonly string simMultipleFile = "default-sim-multiple.json";


        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly INetworkRepository _networkRepository;
        private readonly INetworkBandRepository _networkBandRepository;
        private readonly ISimSizeRepository _simSizeRepo;
        private readonly ISimMultipleRepository _simMultipleRepo;
        // For Dapper
        private readonly IConfiguration _configuration;

        public SqlServerResetRepository(ICategoryRepository categoryRepository,
            IConfiguration configuration,
            IBrandRepository brandRepository,
            IAvailabilityRepository availabilityRepository,
            INetworkRepository networkRepository,
            INetworkBandRepository networkBandRepository,
            ISimSizeRepository simSizeRepo, 
            ISimMultipleRepository simMultipleRepo)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _availabilityRepository = availabilityRepository;
            _networkRepository = networkRepository;
            _networkBandRepository = networkBandRepository;
            _simSizeRepo = simSizeRepo;
            _simMultipleRepo = simMultipleRepo;
        }

        public SqlConnection SqlConnection
        {
            get
            {
                return new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<string> ResetData()
        {
            string result = string.Empty;
            // Delete all data
            result += DeleteAllData();

            // Seed data
            result += SeedAllData();

            return await Task.FromResult(result);
        }

        private string SeedAllData()
        {
            string result = string.Empty;

            result += SeedCategories();
            result += SeedBrands();
            result += SeedAvailability();
            result += SeedNetwork();
            result += SeedNetworkBands();
            result += SeedSimSize();
            result += SeedSimMultiple();

            return result;
        }

        private string SeedBrands()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, brandsFile));
            IEnumerable<Brand>? DefaultBrands = JsonSerializer
                .Deserialize<IEnumerable<Brand>>(jsonData);

            if (DefaultBrands == null) return "0 Brands Added. ";

            foreach (var brand in DefaultBrands)
            {
                _brandRepository.Add(brand);
            }
            _brandRepository.Save();

            return DefaultBrands.Count() + " Brands Added. ";
        }

        private string SeedCategories()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, categoriesFile));
            IEnumerable<Category>? DefaultCategories = JsonSerializer.Deserialize<IEnumerable<Category>>(jsonData);

            if (DefaultCategories == null) return "0 Categories Added. ";

            foreach (Category category in DefaultCategories)
            {
                _categoryRepository.Add(category);
            }
            _categoryRepository.Save();

            return DefaultCategories.Count() + " Categories Added. ";
        }

        private string SeedNetwork()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, networkFile));
            IEnumerable<Network>? DefaultNetworks = 
                JsonSerializer.Deserialize<IEnumerable<Network>>(jsonData);

            if (DefaultNetworks == null) return "0 Networks Added. ";

            foreach (var network in DefaultNetworks)
            {
                _networkRepository.Add(network);
            }
            _networkRepository.Save();

            return DefaultNetworks.Count() + " Networks Added. ";
        }

        private string SeedNetworkBands()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, networkDetailsFile));
            IEnumerable<NetworkDetailSeedModel>? DefaultNetworkDetailSeeds =
                JsonSerializer.Deserialize<IEnumerable<NetworkDetailSeedModel>>(jsonData);

            if (DefaultNetworkDetailSeeds == null) return "0 Network details Added. ";

            // Get all networks (parents of network detail)
            var networks = _networkRepository.GetAll();

            // Loop through each network detail seed model
            foreach (var networkDetailSeed in DefaultNetworkDetailSeeds)
            {
                // Create network detail Model (table)
                var networkDetail = new NetworkBand()
                {
                    Name = networkDetailSeed.Name,
                    NetworkId = networks
                        .Where(x => x.Name.Equals(networkDetailSeed.NetworkName))
                        .Select(x => x.Id)
                        .FirstOrDefault()
                };
                _networkBandRepository.Add(networkDetail);
            }
            _networkBandRepository.Save();

            return DefaultNetworkDetailSeeds.Count() + " Network bands Added. ";
        }

        private string SeedAvailability()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, availabilityFile));
            IEnumerable<Availability>? DefaultAvailability = JsonSerializer
                .Deserialize<IEnumerable<Availability>>(jsonData);

            if (DefaultAvailability == null) return "0 Availabilities Added. ";

            foreach (var availability in DefaultAvailability)
            {
                _availabilityRepository.Add(availability);
            }
            _availabilityRepository.Save();

            return DefaultAvailability.Count() + " Availabilities Added. ";
        }

        private string SeedSimSize()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, simSizeFile));
            IEnumerable<SimSize>? DefaultSimSizes = JsonSerializer
                .Deserialize<IEnumerable<SimSize>>(jsonData);

            if (DefaultSimSizes == null) return "0 Sim Size Added. ";

            foreach (var simSize in DefaultSimSizes)
            {
                _simSizeRepo.Add(simSize);
            }
            _simSizeRepo.Save();

            return DefaultSimSizes.Count() + " Sim Sizes Added. ";
        }

        private string SeedSimMultiple()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, simMultipleFile));
            IEnumerable<SimMultiple>? DefaultSimMultiples = JsonSerializer
                .Deserialize<IEnumerable<SimMultiple>>(jsonData);

            if (DefaultSimMultiples == null) return "0 Sim Multiple Added. ";

            foreach (var simMultiple in DefaultSimMultiples)
            {
                _simMultipleRepo.Add(simMultiple);
            }
            _simMultipleRepo.Save();

            return DefaultSimMultiples.Count() + " Sim Multiples Added. ";
        }

        public string DataFolder
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _dataFolderName);
            }
        }

        private string DeleteAllData()
        {
            // Get connection
            using var connection = SqlConnection;

            // DELETE from tables
            string sql = @"
DELETE FROM Category;
DELETE FROM Brand;
DELETE FROM Availability;
DELETE FROM NetworkBand;
DELETE FROM Network;
DELETE FROM SimSize;
DELETE FROM SimMultiple;
";
            int deletedRows = connection.Execute(sql);

            return deletedRows + " Records DELETED. ";
        }
    }
}
