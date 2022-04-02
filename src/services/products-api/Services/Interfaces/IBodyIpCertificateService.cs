using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IBodyIpCertificateService
    {
        Task<ServiceResponse<BodyIpCertificateDto>> Get(Guid id);
        Task<ServiceResponse<List<BodyIpCertificateDto>>> GetAll();
        Task<ServiceResponse<BodyIpCertificateDto>> Add(BodyIpCertificateCreateDto dto);
        Task<ServiceResponse<BodyIpCertificateDto>> Update(Guid id, BodyIpCertificateUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
