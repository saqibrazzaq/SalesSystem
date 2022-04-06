using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface ICameraTypeService
    {
        Task<ServiceResponse<List<CameraTypeDto>>> GetAll();
        Task<ServiceResponse<CameraTypeDto>> Get(Guid id);
        Task<ServiceResponse<CameraTypeDto>> Add(CameraTypeCreateDto dto);
        Task<ServiceResponse<CameraTypeDto>> Update(Guid id, CameraTypeUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
