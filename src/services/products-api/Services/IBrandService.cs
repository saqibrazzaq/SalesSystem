using products_api.Dtos;

namespace products_api.Services
{
    public interface IBrandService
    {
        Task<ServiceResponse<List<BrandDto>>> GetAll();
        Task<ServiceResponse<BrandDto>> Get(Guid id);
        Task<ServiceResponse<BrandDto>> Add(BrandCreateDto dto);
        Task<ServiceResponse<BrandDto>> Update(Guid id, BrandUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
