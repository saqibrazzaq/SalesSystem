using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class FrameMaterialService : IFrameMaterialService
    {
        private readonly IFrameMaterialRepository _repo;
        private readonly ILogger<FrameMaterialService> _logger;

        public FrameMaterialService(IFrameMaterialRepository frameMaterialRepo, 
            ILogger<FrameMaterialService> logger)
        {
            _repo = frameMaterialRepo;
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
                _repo.Add(frameMaterial);
                _repo.Save();

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
                var availability = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (availability == null) 
                {
                    response = response.GetFailureResponse("FrameMaterial not found.");
                }
                else
                {
                    // Availability found, delete it
                    _repo.Remove(availability);
                    _repo.Save();
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
                var frameMaterial = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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
                var frameMaterials = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var frameMaterial = _repo.GetAll(
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
                    _repo.Update(frameMaterial);
                    _repo.Save();
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
