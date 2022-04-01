using products_api.Dtos;

namespace products_api.Services
{
    public interface INetworkService
    {
        Task<ServiceResponse<List<NetworkDto>>> GetAll();
        Task<ServiceResponse<NetworkDto>> Get(Guid id);
        Task<ServiceResponse<NetworkDto>> Add(NetworkCreateDto dto);
        Task<ServiceResponse<NetworkDto>> Update(Guid id, NetworkUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
