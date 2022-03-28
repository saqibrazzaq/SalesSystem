using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.Repository
{
    public interface IAvailabilityRepository : IRepository<Availability>
    {
        Task<AvailabilitySearchResult> SearchAvailability(
            string? q,
            int? page,
            int? pageSize,
            string? sortBy,
            string? sortDirection);
    }
}
