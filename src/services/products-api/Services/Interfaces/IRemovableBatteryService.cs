using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IRemovableBatteryService
    {
        Task<ServiceResponse<List<RemovableBatteryDto>>> GetAll();
        Task<ServiceResponse<RemovableBatteryDto>> Get(Guid id);
        Task<ServiceResponse<RemovableBatteryDto>> Add(RemovableBatteryCreateDto dto);
        Task<ServiceResponse<RemovableBatteryDto>> Update(Guid id, RemovableBatteryUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
