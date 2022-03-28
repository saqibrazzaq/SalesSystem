using products_api.Dtos;
using products_api.Models;

namespace products_api.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<CategorySearchResult> SearchCategories(
            string? q,
            int? page,
            int? pageSize,
            string? sortBy,
            string? sortDirection);
    }
}
