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


        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        // For Dapper
        private readonly IConfiguration _configuration;

        public SqlServerResetRepository(ICategoryRepository categoryRepository,
            IConfiguration configuration,
            IBrandRepository brandRepository)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
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
";
            int deletedRows = connection.Execute(sql);

            return deletedRows + " Records DELETED. ";
        }
    }
}
