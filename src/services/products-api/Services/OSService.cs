using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class OSService : IOSService
    {
        private readonly IOSRepository _osRepo;
        private readonly ILogger<OSService> _logger;

        public OSService(IOSRepository osRepo, 
            ILogger<OSService> logger)
        {
            _osRepo = osRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _osRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OS count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<OSDto>> Add(
            OSCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<OSDto>();

            try
            {
                // Create model from dto
                var os = new OS { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _osRepo.Add(os);
                _osRepo.Save();

                // Set data
                response.Data = os.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OS create service failed.");
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
                // Get OS
                var os = _osRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (os == null) 
                {
                    response = response.GetFailureResponse("OS not found.");
                }
                else
                {
                    // OS found, delete it
                    _osRepo.Remove(os);
                    _osRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OS delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<OSDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<OSDto>();

            try
            {
                // Get OS
                var os = _osRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (os == null) response = response.GetFailureResponse("OS not found");
                else response.Data = os.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OS service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<OSDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<OSDto>>();

            try
            {
                // Get all OS
                var oses = _osRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var osDtos = new List<OSDto>();
                foreach (var os in oses)
                {
                    osDtos.Add(os.AsDto());
                }
                // Set data
                response.Data = osDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OS service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<OSDto>> Update(
            Guid id, OSUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<OSDto>();

            try
            {
                // Get OS
                var os = _osRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (os == null)
                {
                    response = response.GetFailureResponse("OS not found.");
                }
                else
                {
                    // OS found, update it
                    os.Name = dto.Name;
                    os.Position = dto.Position;
                    
                    // Save in repository
                    _osRepo.Update(os);
                    _osRepo.Save();
                    // Set data
                    response.Data = os.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("OS update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
