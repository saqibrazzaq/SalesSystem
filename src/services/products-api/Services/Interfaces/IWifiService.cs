using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IWifiService
    {
        Task<ServiceResponse<List<WifiDto>>> GetAll();
        Task<ServiceResponse<WifiDto>> Get(Guid id);
        Task<ServiceResponse<WifiDto>> Add(WifiCreateDto dto);
        Task<ServiceResponse<WifiDto>> Update(Guid id, WifiUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
