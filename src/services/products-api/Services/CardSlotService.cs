using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class CardSlotService : ICardSlotService
    {
        private readonly ICardSlotRepository _cardSlotRepo;
        private readonly ILogger<CardSlotService> _logger;

        public CardSlotService(ICardSlotRepository cardSlotRepo, 
            ILogger<CardSlotService> logger)
        {
            _cardSlotRepo = cardSlotRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _cardSlotRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CardSlot count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CardSlotDto>> Add(
            CardSlotCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CardSlotDto>();

            try
            {
                // Create model from dto
                var cardSlot = new CardSlot { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _cardSlotRepo.Add(cardSlot);
                _cardSlotRepo.Save();

                // Set data
                response.Data = cardSlot.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CardSlot create service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> Remove(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get CardSlot
                var cardSlot = _cardSlotRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (cardSlot == null) 
                {
                    response = response.GetFailureResponse("CardSlot not found.");
                }
                else
                {
                    // Chipset found, delete it
                    _cardSlotRepo.Remove(cardSlot);
                    _cardSlotRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CardSlot delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CardSlotDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<CardSlotDto>();

            try
            {
                // Get CardSlot
                var cardSlot = _cardSlotRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (cardSlot == null) response = response.GetFailureResponse("CardSlot not found");
                else response.Data = cardSlot.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CardSlot service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<CardSlotDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<CardSlotDto>>();

            try
            {
                // Get all CardSlot
                var cardSlots = _cardSlotRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var cardSlotDtos = new List<CardSlotDto>();
                foreach (var cardSlot in cardSlots)
                {
                    cardSlotDtos.Add(cardSlot.AsDto());
                }
                // Set data
                response.Data = cardSlotDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CardSlot service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<CardSlotDto>> Update(
            Guid id, CardSlotUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<CardSlotDto>();

            try
            {
                // Get CardSlot
                var cardSlot = _cardSlotRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (cardSlot == null)
                {
                    response = response.GetFailureResponse("CardSlot not found.");
                }
                else
                {
                    // CardSlot found, update it
                    cardSlot.Name = dto.Name;
                    cardSlot.Position = dto.Position;
                    
                    // Save in repository
                    _cardSlotRepo.Update(cardSlot);
                    _cardSlotRepo.Save();
                    // Set data
                    response.Data = cardSlot.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("CardSlot update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
