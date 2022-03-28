using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.Repository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<BrandSearchResult> SearchBrands(
            string? q,
            int? page,
            int? pageSize,
            string? sortBy,
            string? sortDirection);
    }
}
