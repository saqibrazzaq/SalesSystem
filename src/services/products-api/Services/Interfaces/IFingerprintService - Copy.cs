using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IFingerprintService
    {
        Task<ServiceResponse<List<FingerprintDto>>> GetAll();
        Task<ServiceResponse<FingerprintDto>> Get(Guid id);
        Task<ServiceResponse<FingerprintDto>> Add(FingerprintCreateDto dto);
        Task<ServiceResponse<FingerprintDto>> Update(Guid id, FingerprintUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
