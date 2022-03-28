using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Misc;

namespace products_api.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository,
            ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<ServiceResponse<CategorySearchResult>> SearchCategories(
            string? text = null,
            int? page = 1,
            int? pageSize = DefaultValues.PageSize,
            string? sortBy = "position",
            string? sortDirection = "asc"
            )
        {
            try
            {
                // Get categories
                var searchResult = await _categoryRepository.SearchCategories(
                    text, page, pageSize, sortBy, sortDirection
                    );
                // Create response
                var response = new ServiceResponse<CategorySearchResult>()
                {
                    Data = searchResult,
                    Success = true,
                    Message = "Category search successfull"
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<CategorySearchResult>()
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to get categories from repository."
                };
            }
        }
    }
}
