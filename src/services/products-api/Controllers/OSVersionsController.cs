using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OSVersionsController : ControllerBase
    {
        private readonly IOSVersionService _osVersionService;

        public OSVersionsController(IOSVersionService osVersionService)
        {
            _osVersionService = osVersionService;
        }

        [HttpPost("GetAllByOS")]
        public async Task<ActionResult<ServiceResponse<List<OSVersionDto>>>> GetAllByOS(
            List<Guid> osIds)
        {
            // Get response from service
            var response = await _osVersionService.GetAllByOS(osIds);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OSVersionDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _osVersionService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _osVersionService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<OSVersionDto>>> Add(
            [FromBody] OSVersionCreateDto dto)
        {
            // Get response from service
            var response = await _osVersionService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<OSVersionDto>>> Update(
            Guid id, [FromBody] OSVersionUpdateDto dto)
        {
            // Get response from service
            var response = await _osVersionService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _osVersionService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
