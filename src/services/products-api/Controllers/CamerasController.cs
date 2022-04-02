using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CamerasController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CameraDto>>>> GetAll()
        {
            // Get response from service
            var response = await _cameraService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CameraDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _cameraService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _cameraService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CameraDto>>> Add(
            [FromBody] CameraCreateDto dto)
        {
            // Get response from service
            var response = await _cameraService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CameraDto>>> Update(
            Guid id, [FromBody] CameraUpdateDto dto)
        {
            // Get response from service
            var response = await _cameraService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _cameraService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
