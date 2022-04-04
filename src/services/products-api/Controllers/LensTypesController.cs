using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LensTypesController : ControllerBase
    {
        private readonly ILensTypeService _lensTypeService;

        public LensTypesController(ILensTypeService lensTypeService)
        {
            _lensTypeService = lensTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<LensTypeDto>>>> GetAll()
        {
            // Get response from service
            var response = await _lensTypeService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<LensTypeDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _lensTypeService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _lensTypeService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<LensTypeDto>>> Add(
            [FromBody] LensTypeCreateDto dto)
        {
            // Get response from service
            var response = await _lensTypeService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<LensTypeDto>>> Update(
            Guid id, [FromBody] LensTypeUpdateDto dto)
        {
            // Get response from service
            var response = await _lensTypeService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _lensTypeService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
