using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IOSService
    {
        Task<ServiceResponse<List<OSDto>>> GetAll();
        Task<ServiceResponse<OSDto>> Get(Guid id);
        Task<ServiceResponse<OSDto>> GetByName(string name);
        Task<ServiceResponse<OSDto>> Add(OSCreateDto dto);
        Task<ServiceResponse<OSDto>> Update(Guid id, OSUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
