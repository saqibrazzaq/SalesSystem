using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DisplayTechnologiesController : ControllerBase
    {
        private readonly IDisplayTechnologyService _displayTechnologyService;

        public DisplayTechnologiesController(IDisplayTechnologyService displayTechnologyService)
        {
            _displayTechnologyService = displayTechnologyService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DisplayTechnologyDto>>>> GetAll()
        {
            // Get response from service
            var response = await _displayTechnologyService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<DisplayTechnologyDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _displayTechnologyService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _displayTechnologyService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DisplayTechnologyDto>>> Add(
            [FromBody] DisplayTechnologyCreateDto dto)
        {
            // Get response from service
            var response = await _displayTechnologyService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<DisplayTechnologyDto>>> Update(
            Guid id, [FromBody] DisplayTechnologyUpdateDto dto)
        {
            // Get response from service
            var response = await _displayTechnologyService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _displayTechnologyService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
