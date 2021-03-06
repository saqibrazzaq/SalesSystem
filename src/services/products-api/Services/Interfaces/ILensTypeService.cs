using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface ILensTypeService
    {
        Task<ServiceResponse<List<LensTypeDto>>> GetAll();
        Task<ServiceResponse<LensTypeDto>> Get(Guid id);
        Task<ServiceResponse<LensTypeDto>> GetByName(string name);
        Task<ServiceResponse<LensTypeDto>> Add(LensTypeCreateDto dto);
        Task<ServiceResponse<LensTypeDto>> Update(Guid id, LensTypeUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
