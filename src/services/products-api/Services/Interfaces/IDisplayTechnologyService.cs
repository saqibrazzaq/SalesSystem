using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IDisplayTechnologyService
    {
        Task<ServiceResponse<List<DisplayTechnologyDto>>> GetAll();
        Task<ServiceResponse<DisplayTechnologyDto>> Get(Guid id);
        Task<ServiceResponse<DisplayTechnologyDto>> Add(DisplayTechnologyCreateDto dto);
        Task<ServiceResponse<DisplayTechnologyDto>> Update(Guid id, DisplayTechnologyUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
