using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SimSizesController : ControllerBase
    {
        private readonly ISimSizeService _simSizeService;

        public SimSizesController(ISimSizeService simSizeService)
        {
            _simSizeService = simSizeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SimSizeDto>>>> GetAll()
        {
            // Get response from service
            var response = await _simSizeService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<SimSizeDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _simSizeService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _simSizeService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<SimSizeDto>>> Add(
            [FromBody] SimSizeCreateDto dto)
        {
            // Get response from service
            var response = await _simSizeService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<SimSizeDto>>> Update(
            Guid id, [FromBody] SimSizeUpdateDto dto)
        {
            // Get response from service
            var response = await _simSizeService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _simSizeService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
