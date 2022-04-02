using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class OSVersionService : IOSVersionService
    {
        private readonly IOSVersionRepository _osVersionRepo;
        private readonly ILogger<OSVersionService> _logger;

        public OSVersionService(IOSVersionRepository osVersionRepo, 
            ILogger<OSVersionService> logger)
        {
            _osVersionRepo = osVersionRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _osVersionRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OSVersion count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<OSVersionDto>> Add(OSVersionCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<OSVersionDto>();

            try
            {
                // Create model from dto
                var osVersion = new OSVersion { 
                    Name = dto.Name, Position = dto.Position, OSId = dto.OsId };

                // Add in repository
                _osVersionRepo.Add(osVersion);
                _osVersionRepo.Save();

                // Set data
                response.Data = osVersion.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OSVersion create service failed.");
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
                // Get OSVersion
                var osVersion = _osVersionRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (osVersion == null) 
                {
                    response = response.GetFailureResponse("OSVersion not found.");
                }
                else
                {
                    // OSVersion found, delete it
                    _osVersionRepo.Remove(osVersion);
                    _osVersionRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OSVersion delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<OSVersionDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<OSVersionDto>();

            try
            {
                // Get OSVersion
                var osVersion = _osVersionRepo.GetAll()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (osVersion == null) response = response.GetFailureResponse("OSVersion not found");
                else response.Data = osVersion.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OSVersion service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<OSVersionDto>>> GetAllByOS(List<Guid> osIds)
        {
            // Create new response
            var response = new ServiceResponse<List<OSVersionDto>>();

            try
            {
                // If no id passed, return null
                if (osIds == null || osIds.Count() == 0)
                {
                    response = response.GetFailureResponse("OS not found.");
                }
                else
                {
                    // Find OS versions
                    var osVersions = _osVersionRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                        .Where(x => osIds.Contains(x.OSId));
                    // Create Dtos
                    var osVersionDtos = new List<OSVersionDto>();
                    foreach (var osVersion in osVersions)
                    {
                        osVersionDtos.Add(osVersion.AsDto());
                    }
                    // Set data
                    response.Data = osVersionDtos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OSVersion service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<OSVersionDto>> Update(Guid id, OSVersionUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<OSVersionDto>();

            try
            {
                // Get OSVersion
                var osVersion = _osVersionRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (osVersion == null)
                {
                    response = response.GetFailureResponse("OSVersion not found.");
                }
                else
                {
                    // OSVersion found, update it
                    osVersion.Name = dto.Name;
                    osVersion.Position = dto.Position;
                    
                    // Save in repository
                    _osVersionRepo.Update(osVersion);
                    _osVersionRepo.Save();
                    // Set data
                    response.Data = osVersion.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OSVersion update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
