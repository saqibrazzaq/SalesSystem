using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class ChipsetService : IChipsetService
    {
        private readonly IChipsetRepository _chipsetRepo;
        private readonly ILogger<ChipsetService> _logger;

        public ChipsetService(IChipsetRepository chipsetRepo, 
            ILogger<ChipsetService> logger)
        {
            _chipsetRepo = chipsetRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _chipsetRepo.Count();
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
                _chipsetRepo.Add(chipset);
                _chipsetRepo.Save();

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
                var chipset = _chipsetRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (chipset == null) 
                {
                    response = response.GetFailureResponse("Chipset not found.");
                }
                else
                {
                    // Chipset found, delete it
                    _chipsetRepo.Remove(chipset);
                    _chipsetRepo.Save();
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
                var chipset = _chipsetRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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
                var chipsets = _chipsetRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var chipset = _chipsetRepo.GetAll(
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
                    _chipsetRepo.Update(chipset);
                    _chipsetRepo.Save();
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
    }
}
