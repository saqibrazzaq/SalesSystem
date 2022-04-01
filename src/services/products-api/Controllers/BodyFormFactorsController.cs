using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BodyFormFactorsController : ControllerBase
    {
        private readonly IBodyFormFactorService _bodyFormFactorService;

        public BodyFormFactorsController(IBodyFormFactorService bodyFormFactorService)
        {
            _bodyFormFactorService = bodyFormFactorService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BodyFormFactorDto>>>> GetAll()
        {
            // Get response from service
            var response = await _bodyFormFactorService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BodyFormFactorDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _bodyFormFactorService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _bodyFormFactorService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BodyFormFactorDto>>> Add(
            [FromBody] BodyFormFactorCreateDto dto)
        {
            // Get response from service
            var response = await _bodyFormFactorService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BodyFormFactorDto>>> Update(
            Guid id, [FromBody] BodyFormFactorUpdateDto dto)
        {
            // Get response from service
            var response = await _bodyFormFactorService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _bodyFormFactorService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
