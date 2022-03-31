using products_api.Dtos;

namespace products_api.Services
{
    public interface ISimSizeService
    {
        Task<ServiceResponse<List<SimSizeDto>>> GetSimSizes(string? name);
        Task<ServiceResponse<SimSizeDto>> CreateSimSize(SimSizeCreateDto dto);
        Task<ServiceResponse<SimSizeDto>> UpdateSimSize(Guid id, SimSizeUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteSimSize(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
