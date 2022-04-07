using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class ChipsetService : IChipsetService
    {
        private readonly IChipsetRepository _repo;
        private readonly ILogger<ChipsetService> _logger;

        public ChipsetService(IChipsetRepository chipsetRepo, 
            ILogger<ChipsetService> logger)
        {
            _repo = chipsetRepo;
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
                response = response.GetFailureResponse("Chipset count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<ChipsetDto>> Add(
            ChipsetCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<ChipsetDto>();

            try
            {
                // Create model from dto
                var chipset = new Chipset { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(chipset);
                _repo.Save();

                // Set data
                response.Data = chipset.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Chipset create service failed.");
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
                // Get Availability
                var chipset = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (chipset == null) 
                {
                    response = response.GetFailureResponse("Chipset not found.");
                }
                else
                {
                    // Chipset found, delete it
                    _repo.Remove(chipset);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Chipset delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<ChipsetDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<ChipsetDto>();

            try
            {
                // Get Chipset
                var chipset = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (chipset == null) response = response.GetFailureResponse("Chipset not found");
                else response.Data = chipset.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Chipset service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<ChipsetDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<ChipsetDto>>();

            try
            {
                // Get all Chipset
                var chipsets = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var chipsetDtos = new List<ChipsetDto>();
                foreach (var chipset in chipsets)
                {
                    chipsetDtos.Add(chipset.AsDto());
                }
                // Set data
                response.Data = chipsetDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Chipset service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<ChipsetDto>> Update(
            Guid id, ChipsetUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<ChipsetDto>();

            try
            {
                // Get Chipset
                var chipset = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (chipset == null)
                {
                    response = response.GetFailureResponse("Chipset not found.");
                }
                else
                {
                    // Chipset found, update it
                    chipset.Name = dto.Name;
                    chipset.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(chipset);
                    _repo.Save();
                    // Set data
                    response.Data = chipset.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Chipset update service failed.");
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

        public async Task<ServiceResponse<ChipsetDto>> GetByName(string name)
        {
            // Create new response
            var response = new ServiceResponse<ChipsetDto>();

            try
            {
                // Get entity
                var entity = _repo.GetAll()
                    .Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                // Check null
                if (entity == null) response = response.GetFailureResponse("Chipset not found");
                else response.Data = entity.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Chipset service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
