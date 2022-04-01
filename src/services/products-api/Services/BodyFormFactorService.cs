using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class BodyFormFactorService : IBodyFormFactorService
    {
        private readonly IBodyFormFactorRepository _bodyFormFactorRepo;
        private readonly ILogger<BodyFormFactorService> _logger;

        public BodyFormFactorService(IBodyFormFactorRepository bodyFormFactorRepo, 
            ILogger<BodyFormFactorService> logger)
        {
            _bodyFormFactorRepo = bodyFormFactorRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _bodyFormFactorRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyFormFactor count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BodyFormFactorDto>> Add(
            BodyFormFactorCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BodyFormFactorDto>();

            try
            {
                // Create model from dto
                var bodyFormFactor = new BodyFormFactor { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _bodyFormFactorRepo.Add(bodyFormFactor);
                _bodyFormFactorRepo.Save();

                // Set data
                response.Data = bodyFormFactor.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyFormFactor create service failed.");
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
                // Get brand
                var bodyFormFactor = _bodyFormFactorRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bodyFormFactor == null) 
                {
                    response = response.GetFailureResponse("BodyFormFactor not found.");
                }
                else
                {
                    // Brand found, delete it
                    _bodyFormFactorRepo.Remove(bodyFormFactor);
                    _bodyFormFactorRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyFormFactor delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BodyFormFactorDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<BodyFormFactorDto>();

            try
            {
                // Get all BodyFormFactor
                var bodyFormFactor = _bodyFormFactorRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (bodyFormFactor == null) response = response.GetFailureResponse("Body form factor not found.");
                else response.Data = bodyFormFactor.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyFormFactor service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BodyFormFactorDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<BodyFormFactorDto>>();

            try
            {
                // Get all BodyFormFactor
                var bodyFormFactors = _bodyFormFactorRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var bodyFormFactorDtos = new List<BodyFormFactorDto>();
                foreach (var bodyFormFactor in bodyFormFactors)
                {
                    bodyFormFactorDtos.Add(bodyFormFactor.AsDto());
                }
                // Set data
                response.Data = bodyFormFactorDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyFormFactor service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BodyFormFactorDto>> Update(
            Guid id, BodyFormFactorUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BodyFormFactorDto>();

            try
            {
                // Get BodyFormFactor
                var bodyFormFactor = _bodyFormFactorRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bodyFormFactor == null)
                {
                    response = response.GetFailureResponse("BodyFormFactor not found.");
                }
                else
                {
                    // Brand found, update it
                    bodyFormFactor.Name = dto.Name;
                    bodyFormFactor.Position = dto.Position;
                    
                    // Save in repository
                    _bodyFormFactorRepo.Update(bodyFormFactor);
                    _bodyFormFactorRepo.Save();
                    // Set data
                    response.Data = bodyFormFactor.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyFormFactor update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
