using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GPUsController : ControllerBase
    {
        private readonly IGPUService _gpuService;

        public GPUsController(IGPUService gpuService)
        {
            _gpuService = gpuService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GPUDto>>>> GetAll()
        {
            // Get response from service
            var response = await _gpuService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GPUDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _gpuService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _gpuService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GPUDto>>> Add(
            [FromBody] GPUCreateDto dto)
        {
            // Get response from service
            var response = await _gpuService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GPUDto>>> Update(
            Guid id, [FromBody] GPUUpdateDto dto)
        {
            // Get response from service
            var response = await _gpuService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _gpuService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
