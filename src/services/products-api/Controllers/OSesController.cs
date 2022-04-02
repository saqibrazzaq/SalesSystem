using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OSesController : ControllerBase
    {
        private readonly IOSService _osService;

        public OSesController(IOSService osService)
        {
            _osService = osService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OSDto>>>> GetAll()
        {
            // Get response from service
            var response = await _osService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OSDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _osService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _osService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<OSDto>>> Add(
            [FromBody] OSCreateDto dto)
        {
            // Get response from service
            var response = await _osService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<OSDto>>> Update(
            Guid id, [FromBody] OSUpdateDto dto)
        {
            // Get response from service
            var response = await _osService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _osService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
