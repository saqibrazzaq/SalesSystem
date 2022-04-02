using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FrameMaterialsController : ControllerBase
    {
        private readonly IFrameMaterialService _frameMaterialService;

        public FrameMaterialsController(IFrameMaterialService frameMaterialService)
        {
            _frameMaterialService = frameMaterialService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FrameMaterialDto>>>> GetAll()
        {
            // Get response from service
            var response = await _frameMaterialService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FrameMaterialDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _frameMaterialService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _frameMaterialService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FrameMaterialDto>>> Add(
            [FromBody] FrameMaterialCreateDto dto)
        {
            // Get response from service
            var response = await _frameMaterialService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<FrameMaterialDto>>> Update(
            Guid id, [FromBody] FrameMaterialUpdateDto dto)
        {
            // Get response from service
            var response = await _frameMaterialService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _frameMaterialService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
