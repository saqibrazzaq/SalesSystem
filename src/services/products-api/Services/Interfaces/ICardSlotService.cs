using products_api.Dtos;

namespace products_api.Services.Interfaces
{
    public interface ICardSlotService
    {
        Task<ServiceResponse<List<CardSlotDto>>> GetAll();
        Task<ServiceResponse<CardSlotDto>> Get(Guid id);
        Task<ServiceResponse<CardSlotDto>> Add(CardSlotCreateDto dto);
        Task<ServiceResponse<CardSlotDto>> Update(Guid id, CardSlotUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
