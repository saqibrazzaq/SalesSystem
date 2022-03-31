using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepo;
        private readonly ILogger<BrandService> _logger;

        public BrandService(IBrandRepository brandRepo, 
            ILogger<BrandService> logger)
        {
            _brandRepo = brandRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _brandRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BrandDto>> Add(BrandCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BrandDto>();

            try
            {
                // Create model from dto
                var brand = new Brand { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _brandRepo.Add(brand);
                _brandRepo.Save();

                // Set data
                response.Data = brand.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand create service failed.");
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
                // Get brand
                var brand = _brandRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (brand == null) 
                {
                    response = response.GetFailureResponse("Brand not found.");
                }
                else
                {
                    // Brand found, delete it
                    _brandRepo.Remove(brand);
                    _brandRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BrandDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<BrandDto>();

            try
            {
                // Get all brands
                var brand = _brandRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (brand == null) response = response.GetFailureResponse("Brand not found");
                else response.Data = brand.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BrandDto>>> GetAll()
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
                // Set data
                response.Data = brandDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BrandDto>> Update(Guid id, BrandUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BrandDto>();

            try
            {
                // Get brand
                var brand = _brandRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (brand == null)
                {
                    response = response.GetFailureResponse("Brand not found.");
                }
                else
                {
                    // Brand found, update it
                    brand.Name = dto.Name;
                    brand.Position = dto.Position;
                    
                    // Save in repository
                    _brandRepo.Update(brand);
                    _brandRepo.Save();
                    // Set data
                    response.Data = brand.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
