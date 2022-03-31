using products_api.Dtos;

namespace products_api.Services
{
    public interface INetworkBandService
    {
        Task<ServiceResponse<List<NetworkBandDto>>> GetNetworkBands(string? networkName);
        Task<ServiceResponse<NetworkBandDto>> CreateNetworkBand(NetworkBandCreateDto dto);
        Task<ServiceResponse<NetworkBandDto>> UpdateNetworkBand(Guid id, NetworkBandUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteNetworkBand(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
