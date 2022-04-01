using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class FrameMaterialService : IFrameMaterialService
    {
        private readonly IFrameMaterialRepository _frameMaterialRepo;
        private readonly ILogger<FrameMaterialService> _logger;

        public FrameMaterialService(IFrameMaterialRepository frameMaterialRepo, 
            ILogger<FrameMaterialService> logger)
        {
            _frameMaterialRepo = frameMaterialRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _frameMaterialRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FrameMaterialDto>> Add(
            FrameMaterialCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<FrameMaterialDto>();

            try
            {
                // Create model from dto
                var frameMaterial = new FrameMaterial { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _frameMaterialRepo.Add(frameMaterial);
                _frameMaterialRepo.Save();

                // Set data
                response.Data = frameMaterial.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FrameMaterial create service failed.");
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
                // Get BackMaterial
                var availability = _frameMaterialRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (availability == null) 
                {
                    response = response.GetFailureResponse("FrameMaterial not found.");
                }
                else
                {
                    // Availability found, delete it
                    _frameMaterialRepo.Remove(availability);
                    _frameMaterialRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FrameMaterial delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FrameMaterialDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<FrameMaterialDto>();

            try
            {
                // Get FrameMaterial
                var frameMaterial = _frameMaterialRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (frameMaterial == null) response = response.GetFailureResponse("FrameMaterial not found");
                else response.Data = frameMaterial.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FrameMaterial service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<FrameMaterialDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<FrameMaterialDto>>();

            try
            {
                // Get all FrameMaterial
                var frameMaterials = _frameMaterialRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var frameMaterialDtos = new List<FrameMaterialDto>();
                foreach (var frameMaterial in frameMaterials)
                {
                    frameMaterialDtos.Add(frameMaterial.AsDto());
                }
                // Set data
                response.Data = frameMaterialDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FrameMaterial service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FrameMaterialDto>> Update(
            Guid id, FrameMaterialUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<FrameMaterialDto>();

            try
            {
                // Get FrameMaterial
                var frameMaterial = _frameMaterialRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (frameMaterial == null)
                {
                    response = response.GetFailureResponse("FrameMaterial not found.");
                }
                else
                {
                    // FrameMaterial found, update it
                    frameMaterial.Name = dto.Name;
                    frameMaterial.Position = dto.Position;
                    
                    // Save in repository
                    _frameMaterialRepo.Update(frameMaterial);
                    _frameMaterialRepo.Save();
                    // Set data
                    response.Data = frameMaterial.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FrameMaterial update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
