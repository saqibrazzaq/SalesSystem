using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IOSVersionService
    {
        Task<ServiceResponse<List<OSVersionDto>>> GetAllByOS(List<Guid> osIds);
        Task<ServiceResponse<OSVersionDto>> Get(Guid id);
        Task<ServiceResponse<OSVersionDto>> Add(OSVersionCreateDto dto);
        Task<ServiceResponse<OSVersionDto>> Update(Guid id, OSVersionUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
