using products_api.Dtos;

namespace products_api.Services
{
    public interface IBrandService
    {
        Task<ServiceResponse<List<BrandDto>>> GetBrands(string? name);
        Task<ServiceResponse<BrandDto>> CreateBrand(BrandCreateDto dto);
        Task<ServiceResponse<BrandDto>> UpdateBrand(Guid id, BrandUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteBrand(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
