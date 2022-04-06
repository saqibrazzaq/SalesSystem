using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class CardSlotService : ICardSlotService
    {
        private readonly ICardSlotRepository _repo;
        private readonly ILogger<CardSlotService> _logger;

        public CardSlotService(ICardSlotRepository cardSlotRepo, 
            ILogger<CardSlotService> logger)
        {
            _repo = cardSlotRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _repo.Count();
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
                _repo.Add(cardSlot);
                _repo.Save();

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
                var cardSlot = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (cardSlot == null) 
                {
                    response = response.GetFailureResponse("CardSlot not found.");
                }
                else
                {
                    // Chipset found, delete it
                    _repo.Remove(cardSlot);
                    _repo.Save();
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
                var cardSlot = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
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
                var cardSlots = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
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
                var cardSlot = _repo.GetAll(
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
                    _repo.Update(cardSlot);
                    _repo.Save();
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

        public async Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            try
            {
                // Get all entities by id in the list
                var entities = _repo.GetAll(
                    filter: x => ids.Contains(x.Id)
                    ).ToArray();
                _repo.RemoveRange(entities);

                // Set data
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<int>> DeleteAll()
        {
            // Create new response
            var response = new ServiceResponse<int>();

            try
            {
                response.Data = _repo.DeleteAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
