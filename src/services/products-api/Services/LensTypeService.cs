using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class LensTypeService : ILensTypeService
    {
        private readonly ILensTypeRepository _lensTypeRepo;
        private readonly ILogger<LensTypeService> _logger;

        public LensTypeService(ILensTypeRepository lensTypeRepo, 
            ILogger<LensTypeService> logger)
        {
            _lensTypeRepo = lensTypeRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _lensTypeRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("LensType count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<LensTypeDto>> Add(
            LensTypeCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<LensTypeDto>();

            try
            {
                // Create model from dto
                var lensType = new LensType { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _lensTypeRepo.Add(lensType);
                _lensTypeRepo.Save();

                // Set data
                response.Data = lensType.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("LensType create service failed.");
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
                // Get LensType
                var lensType = _lensTypeRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (lensType == null) 
                {
                    response = response.GetFailureResponse("LensType not found.");
                }
                else
                {
                    // LensType found, delete it
                    _lensTypeRepo.Remove(lensType);
                    _lensTypeRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("LensType delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<LensTypeDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<LensTypeDto>();

            try
            {
                // Get LensType
                var lensType = _lensTypeRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (lensType == null) response = response.GetFailureResponse("LensType not found");
                else response.Data = lensType.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("LensType service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<LensTypeDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<LensTypeDto>>();

            try
            {
                // Get all LensType
                var lensTypes = _lensTypeRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var lensTypeDtos = new List<LensTypeDto>();
                foreach (var lensType in lensTypes)
                {
                    lensTypeDtos.Add(lensType.AsDto());
                }
                // Set data
                response.Data = lensTypeDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("LensType service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<LensTypeDto>> Update(
            Guid id, LensTypeUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<LensTypeDto>();

            try
            {
                // Get LensType
                var lensType = _lensTypeRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (lensType == null)
                {
                    response = response.GetFailureResponse("LensType not found.");
                }
                else
                {
                    // LensType found, update it
                    lensType.Name = dto.Name;
                    lensType.Position = dto.Position;
                    
                    // Save in repository
                    _lensTypeRepo.Update(lensType);
                    _lensTypeRepo.Save();
                    // Set data
                    response.Data = lensType.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("LensType update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
