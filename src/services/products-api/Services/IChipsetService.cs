using products_api.Dtos;

namespace products_api.Services
{
    public interface IChipsetService
    {
        Task<ServiceResponse<List<ChipsetDto>>> GetAll();
        Task<ServiceResponse<ChipsetDto>> Get(Guid id);
        Task<ServiceResponse<ChipsetDto>> Add(ChipsetCreateDto dto);
        Task<ServiceResponse<ChipsetDto>> Update(Guid id, ChipsetUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
