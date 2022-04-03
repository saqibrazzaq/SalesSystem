using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IResolutionService
    {
        Task<ServiceResponse<List<ResolutionDto>>> GetAll();
        Task<ServiceResponse<ResolutionDto>> Get(Guid id);
        Task<ServiceResponse<ResolutionDto>> Add(ResolutionCreateDto dto);
        Task<ServiceResponse<ResolutionDto>> Update(Guid id, ResolutionUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
