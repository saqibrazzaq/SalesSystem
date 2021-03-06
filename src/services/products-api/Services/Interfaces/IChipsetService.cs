using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface IChipsetService
    {
        Task<ServiceResponse<List<ChipsetDto>>> GetAll();
        Task<ServiceResponse<ChipsetDto>> Get(Guid id);
        Task<ServiceResponse<ChipsetDto>> GetByName(string name);
        Task<ServiceResponse<ChipsetDto>> Add(ChipsetCreateDto dto);
        Task<ServiceResponse<ChipsetDto>> Update(Guid id, ChipsetUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids);
        Task<ServiceResponse<int>> DeleteAll();
        Task<ServiceResponse<int>> Count();
    }
}
