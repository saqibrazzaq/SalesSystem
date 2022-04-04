using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class CameraTypeService : ICameraTypeService
    {
        private readonly ICameraTypeRepository _repo;
        private readonly ILogger<CameraTypeService> _logger;

        public CameraTypeService(ICameraTypeRepository repo, 
            ILogger<CameraTypeService> logger)
        {
            _repo = repo;
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
                response = response.GetFailureResponse("CameraType count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CameraTypeDto>> Add(CameraTypeCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CameraTypeDto>();

            try
            {
                // Create model from dto
                var cameraType = new CameraType { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(cameraType);
                _repo.Save();

                // Set data
                response.Data = cameraType.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CameraType create service failed.");
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
                // Get CameraType
                var cameraType = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (cameraType == null) 
                {
                    response = response.GetFailureResponse("CameraType not found.");
                }
                else
                {
                    // CameraType found, delete it
                    _repo.Remove(cameraType);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CameraType delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CameraTypeDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<CameraTypeDto>();

            try
            {
                // Get all CameraType
                var cameraType = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (cameraType == null) response = response.GetFailureResponse("CameraType not found");
                else response.Data = cameraType.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CameraType service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<CameraTypeDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<CameraTypeDto>>();

            try
            {
                // Get all CameraType
                var cameraTypes = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var cameraDtos = new List<CameraTypeDto>();
                foreach (var camera in cameraTypes)
                {
                    cameraDtos.Add(camera.AsDto());
                }
                // Set data
                response.Data = cameraDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CameraType service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CameraTypeDto>> Update(Guid id, CameraTypeUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CameraTypeDto>();

            try
            {
                // Get CameraType
                var cameraType = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (cameraType == null)
                {
                    response = response.GetFailureResponse("CameraType not found.");
                }
                else
                {
                    // CameraType found, update it
                    cameraType.Name = dto.Name;
                    cameraType.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(cameraType);
                    _repo.Save();
                    // Set data
                    response.Data = cameraType.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CameraType update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
