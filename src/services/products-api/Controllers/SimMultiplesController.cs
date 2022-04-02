using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SimMultiplesController : ControllerBase
    {
        private readonly ISimMultipleService _simMultipleService;

        public SimMultiplesController(ISimMultipleService simMultipleService)
        {
            _simMultipleService = simMultipleService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SimMultipleDto>>>> GetAll()
        {
            // Get response from service
            var response = await _simMultipleService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<SimMultipleDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _simMultipleService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _simMultipleService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<SimMultipleDto>>> Add(
            [FromBody] SimMultipleCreateDto dto)
        {
            // Get response from service
            var response = await _simMultipleService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<SimMultipleDto>>> Update(
            Guid id, [FromBody] SimMultipleUpdateDto dto)
        {
            // Get response from service
            var response = await _simMultipleService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _simMultipleService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
