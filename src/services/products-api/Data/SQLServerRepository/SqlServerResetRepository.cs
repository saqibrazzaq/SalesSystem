using Dapper;
using products_api.Data.Repository;
using products_api.Models;
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


        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly INetworkRepository _networkRepository;
        // For Dapper
        private readonly IConfiguration _configuration;

        public SqlServerResetRepository(ICategoryRepository categoryRepository,
            IConfiguration configuration,
            IBrandRepository brandRepository,
            IAvailabilityRepository availabilityRepository,
            INetworkRepository networkRepository)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _availabilityRepository = availabilityRepository;
            _networkRepository = networkRepository;
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
DELETE FROM Network;
";
            int deletedRows = connection.Execute(sql);

            return deletedRows + " Records DELETED. ";
        }
    }
}
