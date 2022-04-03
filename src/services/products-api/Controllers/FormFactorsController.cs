using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormFactorsController : ControllerBase
    {
        private readonly IFormFactorService _formFactorService;

        public FormFactorsController(IFormFactorService formFactorService)
        {
            _formFactorService = formFactorService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FormFactorDto>>>> GetAll()
        {
            // Get response from service
            var response = await _formFactorService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FormFactorDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _formFactorService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _formFactorService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FormFactorDto>>> Add(
            [FromBody] FormFactorCreateDto dto)
        {
            // Get response from service
            var response = await _formFactorService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<FormFactorDto>>> Update(
            Guid id, [FromBody] FormFactorUpdateDto dto)
        {
            // Get response from service
            var response = await _formFactorService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _formFactorService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
