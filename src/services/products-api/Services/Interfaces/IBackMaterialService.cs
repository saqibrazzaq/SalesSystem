using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IBackMaterialService
    {
        Task<ServiceResponse<List<BackMaterialDto>>> GetAll();
        Task<ServiceResponse<BackMaterialDto>> Get(Guid id);
        Task<ServiceResponse<BackMaterialDto>> Add(BackMaterialCreateDto dto);
        Task<ServiceResponse<BackMaterialDto>> Update(Guid id, BackMaterialUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
