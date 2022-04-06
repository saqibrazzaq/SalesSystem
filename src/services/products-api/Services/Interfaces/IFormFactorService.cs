using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IFormFactorService
    {
        Task<ServiceResponse<List<FormFactorDto>>> GetAll();
        Task<ServiceResponse<FormFactorDto>> Get(Guid id);
        Task<ServiceResponse<FormFactorDto>> Add(FormFactorCreateDto dto);
        Task<ServiceResponse<FormFactorDto>> Update(Guid id, FormFactorUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
