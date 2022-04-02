using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface ICameraService
    {
        Task<ServiceResponse<List<CameraDto>>> GetAll();
        Task<ServiceResponse<CameraDto>> Get(Guid id);
        Task<ServiceResponse<CameraDto>> Add(CameraCreateDto dto);
        Task<ServiceResponse<CameraDto>> Update(Guid id, CameraUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
