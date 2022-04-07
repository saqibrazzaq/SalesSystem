using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IPhoneService
    {
        Task<ServiceResponse<List<PhoneDto>>> GetAll();
        Task<ServiceResponse<PhoneDto>> Get(Guid id);
        Task<ServiceResponse<PhoneDto>> Add(PhoneCreateDto dto);
        Task<ServiceResponse<PhoneNetworkBandDto>> AddNetworkBand(Guid phoneId, PhoneNetworkBandCreateDto dto);
        Task<ServiceResponse<bool>> RemoveNetworkBand(Guid id);
        Task<ServiceResponse<PhoneNetworkBandDto>> GetNetworkBand(Guid id);
        Task<ServiceResponse<PhoneCameraDto>> AddCamera(Guid phoneId, PhoneCameraCreateDto dto);
        Task<ServiceResponse<PhoneCameraDto>> UpdateCamera(Guid id, PhoneCameraUpdateDto dto);
        Task<ServiceResponse<bool>> RemoveCamera(Guid id);
        Task<ServiceResponse<List<PhoneCameraDto>>> GetAllCamerasByPhone(Guid phoneId);
        Task<ServiceResponse<PhoneCameraDto>> GetCamera(Guid id);
        Task<ServiceResponse<PhoneDto>> Update(Guid id, PhoneUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
