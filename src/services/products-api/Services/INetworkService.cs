using products_api.Dtos;

namespace products_api.Services
{
    public interface INetworkService
    {
        Task<ServiceResponse<List<NetworkDto>>> GetNetworks(string? name);
        Task<ServiceResponse<NetworkDto>> CreateNetwork(NetworkCreateDto dto);
        Task<ServiceResponse<NetworkDto>> UpdateNetwork(Guid id, NetworkUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteNetwork(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
