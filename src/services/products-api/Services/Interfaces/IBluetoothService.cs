using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IBluetoothService
    {
        Task<ServiceResponse<List<BluetoothDto>>> GetAll();
        Task<ServiceResponse<BluetoothDto>> Get(Guid id);
        Task<ServiceResponse<BluetoothDto>> Add(BluetoothCreateDto dto);
        Task<ServiceResponse<BluetoothDto>> Update(Guid id, BluetoothUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
