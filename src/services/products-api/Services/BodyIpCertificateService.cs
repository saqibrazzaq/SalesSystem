using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class BodyIpCertificateService : IBodyIpCertificateService
    {
        private readonly IBodyIpCertificateRepository _bodyIpCertificateRepo;
        private readonly ILogger<BodyIpCertificateService> _logger;

        public BodyIpCertificateService(IBodyIpCertificateRepository bodyIpCertificateRepo, 
            ILogger<BodyIpCertificateService> logger)
        {
            _bodyIpCertificateRepo = bodyIpCertificateRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _bodyIpCertificateRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyIpCertificate count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BodyIpCertificateDto>> Add(
            BodyIpCertificateCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BodyIpCertificateDto>();

            try
            {
                // Create model from dto
                var bodyIpCertificate = new BodyIpCertificate { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _bodyIpCertificateRepo.Add(bodyIpCertificate);
                _bodyIpCertificateRepo.Save();

                // Set data
                response.Data = bodyIpCertificate.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyIpCertificate create service failed.");
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
                // Get IpCertificate
                var bodyIpCertificate = _bodyIpCertificateRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bodyIpCertificate == null) 
                {
                    response = response.GetFailureResponse("BodyIpCertificate not found.");
                }
                else
                {
                    // IpCertificate found, delete it
                    _bodyIpCertificateRepo.Remove(bodyIpCertificate);
                    _bodyIpCertificateRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyIpCertificate delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BodyIpCertificateDto>> Get(
            Guid id)
        {
            // Create new response
            var response = new ServiceResponse<BodyIpCertificateDto>();

            try
            {
                // Get all BodyIpCertificate
                var bodyIpCertificate = _bodyIpCertificateRepo.
                    GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Create Dtos
                if (bodyIpCertificate == null) throw new Exception("Body IP Certificate not found");
                // Set data
                response.Data = bodyIpCertificate.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyIpCertificate service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BodyIpCertificateDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<BodyIpCertificateDto>>();

            try
            {
                // Get all BodyIpCertificate
                var bodyIpCertificates = _bodyIpCertificateRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var bodyIpCertificateDtos = new List<BodyIpCertificateDto>();
                foreach (var bodyIpCertificate in bodyIpCertificates)
                {
                    bodyIpCertificateDtos.Add(bodyIpCertificate.AsDto());
                }
                // Set data
                response.Data = bodyIpCertificateDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyIpCertificate service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BodyIpCertificateDto>> Update(
            Guid id, BodyIpCertificateUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BodyIpCertificateDto>();

            try
            {
                // Get BodyIpCertificate
                var bodyIpCertificate = _bodyIpCertificateRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bodyIpCertificate == null)
                {
                    response = response.GetFailureResponse("BodyIpCertificate not found.");
                }
                else
                {
                    // IpCertificate found, update it
                    bodyIpCertificate.Name = dto.Name;
                    bodyIpCertificate.Position = dto.Position;
                    
                    // Save in repository
                    _bodyIpCertificateRepo.Update(bodyIpCertificate);
                    _bodyIpCertificateRepo.Save();
                    // Set data
                    response.Data = bodyIpCertificate.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BodyIpCertificate update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
