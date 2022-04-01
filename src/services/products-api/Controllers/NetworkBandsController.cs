using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NetworkBandsController : ControllerBase
    {
        private readonly INetworkBandService _networkBandService;

        public NetworkBandsController(INetworkBandService networkBandService)
        {
            _networkBandService = networkBandService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<NetworkBandDto>>>> GetAll(
            Guid networkId)
        {
            // Get response from service
            var response = await _networkBandService.GetAll(networkId);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<NetworkBandDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _networkBandService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count(Guid networkId)
        {
            // Get response from service
            var response = await _networkBandService.Count(networkId);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<NetworkBandDto>>> Add(
            [FromBody] NetworkBandCreateDto dto)
        {
            // Get response from service
            var response = await _networkBandService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<NetworkBandDto>>> Update(
            Guid id, [FromBody] NetworkBandUpdateDto dto)
        {
            // Get response from service
            var response = await _networkBandService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _networkBandService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
