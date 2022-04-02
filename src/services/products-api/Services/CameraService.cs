using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _cameraRepo;
        private readonly ILogger<CameraService> _logger;

        public CameraService(ICameraRepository cameraRepo, 
            ILogger<CameraService> logger)
        {
            _cameraRepo = cameraRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _cameraRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Camera count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CameraDto>> Add(CameraCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CameraDto>();

            try
            {
                // Create model from dto
                var camera = new Camera { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _cameraRepo.Add(camera);
                _cameraRepo.Save();

                // Set data
                response.Data = camera.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Camera create service failed.");
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
                // Get camera
                var camera = _cameraRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (camera == null) 
                {
                    response = response.GetFailureResponse("Camera not found.");
                }
                else
                {
                    // Camera found, delete it
                    _cameraRepo.Remove(camera);
                    _cameraRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Camera delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CameraDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<CameraDto>();

            try
            {
                // Get all Camera
                var camera = _cameraRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (camera == null) response = response.GetFailureResponse("Camera not found");
                else response.Data = camera.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Camera service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<CameraDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<CameraDto>>();

            try
            {
                // Get all Camera
                var cameras = _cameraRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var cameraDtos = new List<CameraDto>();
                foreach (var camera in cameras)
                {
                    cameraDtos.Add(camera.AsDto());
                }
                // Set data
                response.Data = cameraDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Camera service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CameraDto>> Update(Guid id, CameraUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CameraDto>();

            try
            {
                // Get Camera
                var camera = _cameraRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (camera == null)
                {
                    response = response.GetFailureResponse("Camera not found.");
                }
                else
                {
                    // Camera found, update it
                    camera.Name = dto.Name;
                    camera.Position = dto.Position;
                    
                    // Save in repository
                    _cameraRepo.Update(camera);
                    _cameraRepo.Save();
                    // Set data
                    response.Data = camera.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Camera update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
