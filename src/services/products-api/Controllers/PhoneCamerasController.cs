using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneCamerasController : ControllerBase
    {
        private readonly IPhoneCameraService _phoneCameraService;

        public PhoneCamerasController(IPhoneCameraService phoneCameraService)
        {
            _phoneCameraService = phoneCameraService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PhoneCameraDto>>>> GetAllByPhone(
            Guid phoneId)
        {
            // Get response from service
            var response = await _phoneCameraService.GetAllByPhone(phoneId);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PhoneCameraDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _phoneCameraService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _phoneCameraService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PhoneCameraDto>>> Add(
            [FromBody] PhoneCameraCreateDto dto)
        {
            // Get response from service
            var response = await _phoneCameraService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<PhoneCameraDto>>> Update(
            Guid id, [FromBody] PhoneCameraUpdateDto dto)
        {
            // Get response from service
            var response = await _phoneCameraService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _phoneCameraService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
