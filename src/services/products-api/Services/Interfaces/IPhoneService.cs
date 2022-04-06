using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IPhoneService
    {
        Task<ServiceResponse<List<PhoneDto>>> GetAll();
        Task<ServiceResponse<PhoneDto>> Get(Guid id);
        Task<ServiceResponse<PhoneDto>> Add(PhoneCreateDto dto);
        Task<ServiceResponse<PhoneDto>> Update(Guid id, PhoneUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
