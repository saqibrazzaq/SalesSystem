using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardSlotsController : ControllerBase
    {
        private readonly ICardSlotService _cardSlotService;

        public CardSlotsController(ICardSlotService cardSlotService)
        {
            _cardSlotService = cardSlotService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CardSlotDto>>>> GetAll()
        {
            // Get response from service
            var response = await _cardSlotService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CardSlotDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _cardSlotService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _cardSlotService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CardSlotDto>>> Add(
            [FromBody] CardSlotCreateDto dto)
        {
            // Get response from service
            var response = await _cardSlotService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CardSlotDto>>> Update(
            Guid id, [FromBody] CardSlotUpdateDto dto)
        {
            // Get response from service
            var response = await _cardSlotService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _cardSlotService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
