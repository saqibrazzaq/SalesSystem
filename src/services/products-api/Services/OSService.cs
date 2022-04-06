using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class OSService : IOSService
    {
        private readonly IOSRepository _repo;
        private readonly ILogger<OSService> _logger;

        public OSService(IOSRepository osRepo, 
            ILogger<OSService> logger)
        {
            _repo = osRepo;
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
                _repo.Add(os);
                _repo.Save();

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
                var os = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (os == null) 
                {
                    response = response.GetFailureResponse("OS not found.");
                }
                else
                {
                    // OS found, delete it
                    _repo.Remove(os);
                    _repo.Save();
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
                var os = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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

        public async Task<ServiceResponse<OSDto>> GetByName(string name)
        {
            // Create new response
            var response = new ServiceResponse<OSDto>();

            try
            {
                // Get OS
                var os = _repo.GetAll()
                    .Where(x => x.Name == name)
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
                var oses = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var os = _repo.GetAll(
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
                    _repo.Update(os);
                    _repo.Save();
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
