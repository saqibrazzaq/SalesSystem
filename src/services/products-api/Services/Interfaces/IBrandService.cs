using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IBrandService
    {
        Task<ServiceResponse<List<BrandDto>>> GetAll();
        Task<ServiceResponse<BrandDto>> Get(Guid id);
        Task<ServiceResponse<BrandDto>> Add(BrandCreateDto dto);
        Task<ServiceResponse<BrandDto>> Update(Guid id, BrandUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
