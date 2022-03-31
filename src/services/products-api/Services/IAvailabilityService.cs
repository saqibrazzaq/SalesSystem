using products_api.Dtos;

namespace products_api.Services
{
    public interface IAvailabilityService
    {
        Task<ServiceResponse<List<AvailabilityDto>>> GetAvailabilities(string? name);
        Task<ServiceResponse<AvailabilityDto>> CreateAvailability(AvailabilityCreateDto dto);
        Task<ServiceResponse<AvailabilityDto>> UpdateAvailability(Guid id, AvailabilityUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteAvailability(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
