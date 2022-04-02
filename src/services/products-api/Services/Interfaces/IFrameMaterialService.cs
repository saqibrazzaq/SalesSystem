using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IFrameMaterialService
    {
        Task<ServiceResponse<List<FrameMaterialDto>>> GetAll();
        Task<ServiceResponse<FrameMaterialDto>> Get(Guid id);
        Task<ServiceResponse<FrameMaterialDto>> Add(FrameMaterialCreateDto dto);
        Task<ServiceResponse<FrameMaterialDto>> Update(Guid id, FrameMaterialUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
