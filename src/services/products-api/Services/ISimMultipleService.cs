using products_api.Dtos;

namespace products_api.Services
{
    public interface ISimMultipleService
    {
        Task<ServiceResponse<List<SimMultipleDto>>> GetSimMultiples(string? name);
        Task<ServiceResponse<SimMultipleDto>> CreateSimMultiple(SimMultipleCreateDto dto);
        Task<ServiceResponse<SimMultipleDto>> UpdateSimMultiple(Guid id, SimMultipleUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteSimMultiple(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
