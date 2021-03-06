using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BatteryTypesController : ControllerBase
    {
        private readonly IBatteryTypeService _batteryTypesService;

        public BatteryTypesController(IBatteryTypeService batteryTypeService)
        {
            _batteryTypesService = batteryTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BatteryTypeDto>>>> GetAll()
        {
            // Get response from service
            var response = await _batteryTypesService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BatteryTypeDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _batteryTypesService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _batteryTypesService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BatteryTypeDto>>> Add(
            [FromBody] BatteryTypeCreateDto dto)
        {
            // Get response from service
            var response = await _batteryTypesService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BatteryTypeDto>>> Update(
            Guid id, [FromBody] BatteryTypeUpdateDto dto)
        {
            // Get response from service
            var response = await _batteryTypesService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _batteryTypesService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
