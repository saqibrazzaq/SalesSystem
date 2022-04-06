using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryDto>>> GetAll();
        Task<ServiceResponse<CategoryDto>> Get(Guid id);
        Task<ServiceResponse<CategoryDto>> Add(CategoryCreateDto dto);
        Task<ServiceResponse<CategoryDto>> Update(Guid id, CategoryUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
