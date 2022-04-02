using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FingerprintsController : ControllerBase
    {
        private readonly IFingerprintService _fingerprintService;

        public FingerprintsController(IFingerprintService fingerprintService)
        {
            _fingerprintService = fingerprintService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FingerprintDto>>>> GetAll()
        {
            // Get response from service
            var response = await _fingerprintService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FingerprintDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _fingerprintService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _fingerprintService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FingerprintDto>>> Add(
            [FromBody] FingerprintCreateDto dto)
        {
            // Get response from service
            var response = await _fingerprintService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<FingerprintDto>>> Update(
            Guid id, [FromBody] FingerprintUpdateDto dto)
        {
            // Get response from service
            var response = await _fingerprintService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _fingerprintService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
