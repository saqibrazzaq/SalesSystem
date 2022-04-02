using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class FingerprintService : IFingerprintService
    {
        private readonly IFingerprintRepository _fingerprintRepo;
        private readonly ILogger<FingerprintService> _logger;

        public FingerprintService(IFingerprintRepository fingerprintRepo, 
            ILogger<FingerprintService> logger)
        {
            _fingerprintRepo = fingerprintRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _fingerprintRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Fingerprint count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FingerprintDto>> Add(FingerprintCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<FingerprintDto>();

            try
            {
                // Create model from dto
                var fingerprint = new Fingerprint { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _fingerprintRepo.Add(fingerprint);
                _fingerprintRepo.Save();

                // Set data
                response.Data = fingerprint.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Fingerprint create service failed.");
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
                // Get Fingerprint
                var fingerprint = _fingerprintRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (fingerprint == null) 
                {
                    response = response.GetFailureResponse("Fingerprint not found.");
                }
                else
                {
                    // Fingerprint found, delete it
                    _fingerprintRepo.Remove(fingerprint);
                    _fingerprintRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Fingerprint delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FingerprintDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<FingerprintDto>();

            try
            {
                // Get all Fingerprint
                var fingerprint = _fingerprintRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (fingerprint == null) response = response.GetFailureResponse("Fingerprint not found");
                else response.Data = fingerprint.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Fingerprint service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<FingerprintDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<FingerprintDto>>();

            try
            {
                // Get all Fingerprint
                var fingerprints = _fingerprintRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var fingerprintDtos = new List<FingerprintDto>();
                foreach (var fingerprint in fingerprints)
                {
                    fingerprintDtos.Add(fingerprint.AsDto());
                }
                // Set data
                response.Data = fingerprintDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Fingerprint service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FingerprintDto>> Update(Guid id, FingerprintUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<FingerprintDto>();

            try
            {
                // Get Fingerprint
                var fingerprint = _fingerprintRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (fingerprint == null)
                {
                    response = response.GetFailureResponse("Fingerprint not found.");
                }
                else
                {
                    // Fingerprint found, update it
                    fingerprint.Name = dto.Name;
                    fingerprint.Position = dto.Position;
                    
                    // Save in repository
                    _fingerprintRepo.Update(fingerprint);
                    _fingerprintRepo.Save();
                    // Set data
                    response.Data = fingerprint.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Fingerprint update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
