using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RemovableBatteriesController : ControllerBase
    {
        private readonly IRemovableBatteryService _removableBatteryService;

        public RemovableBatteriesController(IRemovableBatteryService removableBatteryService)
        {
            _removableBatteryService = removableBatteryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<RemovableBatteryDto>>>> GetAll()
        {
            // Get response from service
            var response = await _removableBatteryService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<RemovableBatteryDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _removableBatteryService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _removableBatteryService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<RemovableBatteryDto>>> Add(
            [FromBody] RemovableBatteryCreateDto dto)
        {
            // Get response from service
            var response = await _removableBatteryService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<RemovableBatteryDto>>> Update(
            Guid id, [FromBody] RemovableBatteryUpdateDto dto)
        {
            // Get response from service
            var response = await _removableBatteryService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _removableBatteryService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
