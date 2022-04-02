using products_api.Dtos;

namespace products_api.Services
{
    public interface IDisplayTechnologyService
    {
        Task<ServiceResponse<List<DisplayTechnologyDto>>> GetAll();
        Task<ServiceResponse<DisplayTechnologyDto>> Get(Guid id);
        Task<ServiceResponse<DisplayTechnologyDto>> Add(DisplayTechnologyCreateDto dto);
        Task<ServiceResponse<DisplayTechnologyDto>> Update(Guid id, DisplayTechnologyUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
