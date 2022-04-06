using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IGPUService
    {
        Task<ServiceResponse<List<GPUDto>>> GetAll();
        Task<ServiceResponse<GPUDto>> Get(Guid id);
        Task<ServiceResponse<GPUDto>> Add(GPUCreateDto dto);
        Task<ServiceResponse<GPUDto>> Update(Guid id, GPUUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
