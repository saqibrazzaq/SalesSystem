using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class GPUService : IGPUService
    {
        private readonly IGPURepository _gpuRepo;
        private readonly ILogger<GPUService> _logger;

        public GPUService(IGPURepository gpuRepo, 
            ILogger<GPUService> logger)
        {
            _gpuRepo = gpuRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _gpuRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("GPU count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<GPUDto>> Add(
            GPUCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<GPUDto>();

            try
            {
                // Create model from dto
                var gpu = new GPU { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _gpuRepo.Add(gpu);
                _gpuRepo.Save();

                // Set data
                response.Data = gpu.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("GPU create service failed.");
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
                // Get GPU
                var gpu = _gpuRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (gpu == null) 
                {
                    response = response.GetFailureResponse("GPU not found.");
                }
                else
                {
                    // GPU found, delete it
                    _gpuRepo.Remove(gpu);
                    _gpuRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("GPU delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<GPUDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<GPUDto>();

            try
            {
                // Get GPU
                var gpu = _gpuRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (gpu == null) response = response.GetFailureResponse("GPU not found");
                else response.Data = gpu.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("GPU service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<GPUDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<GPUDto>>();

            try
            {
                // Get all GPU
                var gpus = _gpuRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var gpuDtos = new List<GPUDto>();
                foreach (var gpu in gpus)
                {
                    gpuDtos.Add(gpu.AsDto());
                }
                // Set data
                response.Data = gpuDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("GPU service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<GPUDto>> Update(
            Guid id, GPUUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<GPUDto>();

            try
            {
                // Get GPU
                var gpu = _gpuRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (gpu == null)
                {
                    response = response.GetFailureResponse("GPU not found.");
                }
                else
                {
                    // GPU found, update it
                    gpu.Name = dto.Name;
                    gpu.Position = dto.Position;
                    
                    // Save in repository
                    _gpuRepo.Update(gpu);
                    _gpuRepo.Save();
                    // Set data
                    response.Data = gpu.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("GPU update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
