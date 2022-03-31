using products_api.Dtos;

namespace products_api.Services
{
    public interface IBodyFormFactorService
    {
        Task<ServiceResponse<List<BodyFormFactorDto>>> GetBodyFormFactors(string? name);
        Task<ServiceResponse<BodyFormFactorDto>> CreateBodyFormFactor(BodyFormFactorCreateDto dto);
        Task<ServiceResponse<BodyFormFactorDto>> UpdateBodyFormFactor(Guid id, BodyFormFactorUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteBodyFormFactor(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
