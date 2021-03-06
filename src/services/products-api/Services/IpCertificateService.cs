using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class IpCertificateService : IIpCertificateService
    {
        private readonly IIpCertificateRepository _repo;
        private readonly ILogger<IpCertificateService> _logger;

        public IpCertificateService(IIpCertificateRepository ipCertificateRepo, 
            ILogger<IpCertificateService> logger)
        {
            _repo = ipCertificateRepo;
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
                response = response.GetFailureResponse("IpCertificate count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<IpCertificateDto>> Add(
            IpCertificateCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<IpCertificateDto>();

            try
            {
                // Create model from dto
                var ipCertificate = new IpCertificate { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(ipCertificate);
                _repo.Save();

                // Set data
                response.Data = ipCertificate.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("IpCertificate create service failed.");
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
                var bodyIpCertificate = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bodyIpCertificate == null) 
                {
                    response = response.GetFailureResponse("IpCertificate not found.");
                }
                else
                {
                    // IpCertificate found, delete it
                    _repo.Remove(bodyIpCertificate);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("IpCertificate delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<IpCertificateDto>> Get(
            Guid id)
        {
            // Create new response
            var response = new ServiceResponse<IpCertificateDto>();

            try
            {
                // Get IpCertificate
                var ipCertificate = _repo.
                    GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check not found
                if (ipCertificate == null)
                    response = response.GetFailureResponse("IP Certificate not found");
                else
                    response.Data = ipCertificate.AsDto();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("IpCertificate service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<IpCertificateDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<IpCertificateDto>>();

            try
            {
                // Get all IpCertificate
                var ipCertificates = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var ipCertificateDtos = new List<IpCertificateDto>();
                foreach (var ipCertificate in ipCertificates)
                {
                    ipCertificateDtos.Add(ipCertificate.AsDto());
                }
                // Set data
                response.Data = ipCertificateDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("IpCertificate service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<IpCertificateDto>> Update(
            Guid id, IpCertificateUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<IpCertificateDto>();

            try
            {
                // Get IpCertificate
                var bodyIpCertificate = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (bodyIpCertificate == null)
                {
                    response = response.GetFailureResponse("IpCertificate not found.");
                }
                else
                {
                    // IpCertificate found, update it
                    bodyIpCertificate.Name = dto.Name;
                    bodyIpCertificate.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(bodyIpCertificate);
                    _repo.Save();
                    // Set data
                    response.Data = bodyIpCertificate.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("IpCertificate update service failed.");
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
