using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface INetworkBandService
    {
        Task<ServiceResponse<NetworkBandDto>> Get(Guid id);
        Task<ServiceResponse<List<NetworkBandDto>>> GetAll(Guid networkId);
        Task<ServiceResponse<NetworkBandDto>> Add(NetworkBandCreateDto dto);
        Task<ServiceResponse<NetworkBandDto>> Update(Guid id, NetworkBandUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count(Guid networkId);
    }
}
