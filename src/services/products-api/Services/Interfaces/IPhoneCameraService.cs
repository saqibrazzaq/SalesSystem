using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IPhoneCameraService
    {
        Task<ServiceResponse<List<PhoneCameraDto>>> GetAllByPhone(Guid phoneId);
        Task<ServiceResponse<PhoneCameraDto>> Get(Guid id);
        Task<ServiceResponse<PhoneCameraDto>> Add(PhoneCameraCreateDto dto);
        Task<ServiceResponse<PhoneCameraDto>> Update(Guid id, PhoneCameraUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
