using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IAvailabilityService
    {
        Task<ServiceResponse<List<AvailabilityDto>>> GetAll();
        Task<ServiceResponse<AvailabilityDto>> Get(Guid id);
        Task<ServiceResponse<AvailabilityDto>> Add(AvailabilityCreateDto dto);
        Task<ServiceResponse<AvailabilityDto>> Update(Guid id, AvailabilityUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
