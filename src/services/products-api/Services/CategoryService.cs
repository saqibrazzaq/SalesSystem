using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Misc;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository,
            ILogger<CategoryService> logger)
        {
            _repo = categoryRepository;
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
                var searchResult = await _repo.SearchCategories(
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

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _repo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CategoryDto>> Add(
            CategoryCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CategoryDto>();

            try
            {
                // Create model from dto
                var entity = new Category { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(entity);
                _repo.Save();

                // Set data
                response.Data = entity.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Create service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> Remove(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get entity
                var entity = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (entity == null)
                {
                    response = response.GetFailureResponse("Not found.");
                }
                else
                {
                    // entity found, delete it
                    _repo.Remove(entity);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CategoryDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<CategoryDto>();

            try
            {
                // Get entity
                var entity = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (entity == null) response = response.GetFailureResponse("Not found");
                else response.Data = entity.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<CategoryDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<CategoryDto>>();

            try
            {
                // Get all entities
                var entities = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var entityDtos = new List<CategoryDto>();
                foreach (var entity in entities)
                {
                    entityDtos.Add(entity.AsDto());
                }
                // Set data
                response.Data = entityDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CategoryDto>> Update(
            Guid id, CategoryUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CategoryDto>();

            try
            {
                // Get entity
                var entity = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (entity == null)
                {
                    response = response.GetFailureResponse("Not found.");
                }
                else
                {
                    // entity found, update it
                    entity.Name = dto.Name;
                    entity.Position = dto.Position;

                    // Save in repository
                    _repo.Update(entity);
                    _repo.Save();
                    // Set data
                    response.Data = entity.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Update service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            try
            {
                // Get all entities by id in the list
                var entities = _repo.GetAll(
                    filter: x => ids.Contains(x.Id)
                    ).ToArray();
                _repo.RemoveRange(entities);

                // Set data
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<int>> DeleteAll()
        {
            // Create new response
            var response = new ServiceResponse<int>();

            try
            {
                response.Data = _repo.DeleteAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
