using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ChipsetsController : ControllerBase
    {
        private readonly IChipsetService _chipsetService;

        public ChipsetsController(IChipsetService chipsetService)
        {
            _chipsetService = chipsetService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ChipsetDto>>>> GetAll()
        {
            // Get response from service
            var response = await _chipsetService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ChipsetDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _chipsetService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _chipsetService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ChipsetDto>>> Add(
            [FromBody] ChipsetCreateDto dto)
        {
            // Get response from service
            var response = await _chipsetService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ChipsetDto>>> Update(
            Guid id, [FromBody] ChipsetUpdateDto dto)
        {
            // Get response from service
            var response = await _chipsetService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _chipsetService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
