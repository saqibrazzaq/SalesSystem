using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IIpCertificateService
    {
        Task<ServiceResponse<IpCertificateDto>> Get(Guid id);
        Task<ServiceResponse<List<IpCertificateDto>>> GetAll();
        Task<ServiceResponse<IpCertificateDto>> Add(IpCertificateCreateDto dto);
        Task<ServiceResponse<IpCertificateDto>> Update(Guid id, IpCertificateUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
