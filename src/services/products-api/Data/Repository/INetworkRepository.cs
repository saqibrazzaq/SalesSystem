using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.Repository
{
    public interface INetworkRepository : IRepository<Network>
    {
        Task<NetworkSearchResult> SearchNetworks(
            string? q,
            int? page,
            int? pageSize,
            string? sortBy,
            string? sortDirection);

        Task<Network?> GetNetworkWithAllDetails(string name);
    }
}
