using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IBatteryTypeService
    {
        Task<ServiceResponse<List<BatteryTypeDto>>> GetAll();
        Task<ServiceResponse<BatteryTypeDto>> Get(Guid id);
        Task<ServiceResponse<BatteryTypeDto>> Add(BatteryTypeCreateDto dto);
        Task<ServiceResponse<BatteryTypeDto>> Update(Guid id, BatteryTypeUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
