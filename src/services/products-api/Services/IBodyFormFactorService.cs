using products_api.Dtos;

namespace products_api.Services
{
    public interface IBodyFormFactorService
    {
        Task<ServiceResponse<List<BodyFormFactorDto>>> GetAll();
        Task<ServiceResponse<BodyFormFactorDto>> Get(Guid id);
        Task<ServiceResponse<BodyFormFactorDto>> Add(BodyFormFactorCreateDto dto);
        Task<ServiceResponse<BodyFormFactorDto>> Update(Guid id, BodyFormFactorUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
