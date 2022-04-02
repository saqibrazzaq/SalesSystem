using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NetworksController : ControllerBase
    {
        private readonly INetworkService _networkService;

        public NetworksController(INetworkService networkService)
        {
            _networkService = networkService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<NetworkDto>>>> GetAll()
        {
            // Get response from service
            var response = await _networkService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<NetworkDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _networkService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _networkService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<NetworkDto>>> Add(
            [FromBody] NetworkCreateDto dto)
        {
            // Get response from service
            var response = await _networkService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<NetworkDto>>> Update(
            Guid id, [FromBody] NetworkUpdateDto dto)
        {
            // Get response from service
            var response = await _networkService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _networkService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
