using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class ResolutionService : IResolutionService
    {
        private readonly IResolutionRepository _repo;
        private readonly ILogger<ResolutionService> _logger;

        public ResolutionService(IResolutionRepository resolutionRepo, 
            ILogger<ResolutionService> logger)
        {
            _repo = resolutionRepo;
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
                response = response.GetFailureResponse("Resolution count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<ResolutionDto>> Add(
            ResolutionCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<ResolutionDto>();

            try
            {
                // Create model from dto
                var resolution = new Resolution { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(resolution);
                _repo.Save();

                // Set data
                response.Data = resolution.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Resolution create service failed.");
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
                // Get Resolution
                var resolution = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (resolution == null) 
                {
                    response = response.GetFailureResponse("Resolution not found.");
                }
                else
                {
                    // Resolution found, delete it
                    _repo.Remove(resolution);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Resolution delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<ResolutionDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<ResolutionDto>();

            try
            {
                // Get Resolution
                var resolution = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (resolution == null) response = response.GetFailureResponse("Resolution not found");
                else response.Data = resolution.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Resolution service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<ResolutionDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<ResolutionDto>>();

            try
            {
                // Get all Resolution
                var resolutions = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var resolutionDtos = new List<ResolutionDto>();
                foreach (var resolution in resolutions)
                {
                    resolutionDtos.Add(resolution.AsDto());
                }
                // Set data
                response.Data = resolutionDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Resolution service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<ResolutionDto>> Update(
            Guid id, ResolutionUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<ResolutionDto>();

            try
            {
                // Get Resolution
                var resolution = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (resolution == null)
                {
                    response = response.GetFailureResponse("Resolution not found.");
                }
                else
                {
                    // Resolution found, update it
                    resolution.Name = dto.Name;
                    resolution.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(resolution);
                    _repo.Save();
                    // Set data
                    response.Data = resolution.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Resolution update service failed.");
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
