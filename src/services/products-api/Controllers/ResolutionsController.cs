using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResolutionsController : ControllerBase
    {
        private readonly IResolutionService _resolutionService;

        public ResolutionsController(IResolutionService resolutionService)
        {
            _resolutionService = resolutionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ResolutionDto>>>> GetAll()
        {
            // Get response from service
            var response = await _resolutionService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ResolutionDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _resolutionService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _resolutionService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ResolutionDto>>> Add(
            [FromBody] ResolutionCreateDto dto)
        {
            // Get response from service
            var response = await _resolutionService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ResolutionDto>>> Update(
            Guid id, [FromBody] ResolutionUpdateDto dto)
        {
            // Get response from service
            var response = await _resolutionService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _resolutionService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
