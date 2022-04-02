using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface ISimMultipleService
    {
        Task<ServiceResponse<SimMultipleDto>> Get(Guid id);
        Task<ServiceResponse<List<SimMultipleDto>>> GetAll();
        Task<ServiceResponse<SimMultipleDto>> Add(SimMultipleCreateDto dto);
        Task<ServiceResponse<SimMultipleDto>> Update(Guid id, SimMultipleUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
