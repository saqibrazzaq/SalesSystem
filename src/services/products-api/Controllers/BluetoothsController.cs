using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BluetoothsController : ControllerBase
    {
        private readonly IBluetoothService _bluetoothService;

        public BluetoothsController(IBluetoothService bluetoothService)
        {
            _bluetoothService = bluetoothService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BluetoothDto>>>> GetAll()
        {
            // Get response from service
            var response = await _bluetoothService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BluetoothDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _bluetoothService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _bluetoothService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BluetoothDto>>> Add(
            [FromBody] BluetoothCreateDto dto)
        {
            // Get response from service
            var response = await _bluetoothService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BluetoothDto>>> Update(
            Guid id, [FromBody] BluetoothUpdateDto dto)
        {
            // Get response from service
            var response = await _bluetoothService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _bluetoothService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
