using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WifisController : ControllerBase
    {
        private readonly IWifiService _wifiService;

        public WifisController(IWifiService wifiService)
        {
            _wifiService = wifiService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<WifiDto>>>> GetAll()
        {
            // Get response from service
            var response = await _wifiService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<WifiDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _wifiService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _wifiService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<WifiDto>>> Add(
            [FromBody] WifiCreateDto dto)
        {
            // Get response from service
            var response = await _wifiService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<WifiDto>>> Update(
            Guid id, [FromBody] WifiUpdateDto dto)
        {
            // Get response from service
            var response = await _wifiService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _wifiService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
