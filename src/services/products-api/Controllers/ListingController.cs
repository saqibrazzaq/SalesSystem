using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly INetworkService _networkService;
        private readonly INetworkBandService _networkBandService;
        private readonly ISimSizeService _simSizeService;
        private readonly ISimMultipleService _simMultipleService;
        private readonly IBodyFormFactorService _bodyFormFactorService;

        public ListingController(
            INetworkService networkService,
            INetworkBandService networkBandService,
            ISimSizeService simSizeService,
            ISimMultipleService simMultipleService, 
            IBodyFormFactorService bodyFormFactorService)
        {
            _networkService = networkService;
            _networkBandService = networkBandService;
            _simSizeService = simSizeService;
            _simMultipleService = simMultipleService;
            _bodyFormFactorService = bodyFormFactorService;
        }

        [HttpGet("networks")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<NetworkDto>>>>
            GetNetworks(string? name = null)
        {
            // Get response from service
            var response = await _networkService.GetNetworks(name);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("networkBands")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<NetworkBandDto>>>>
            GetNetworkBands(string networkName)
        {
            // Get response from service
            var response = await _networkBandService.GetNetworkBands(networkName);
            
            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("simSizes")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SimSizeDto>>>>
            GetSimSizes(string? name = null)
        {
            // Get response from service
            var response = await _simSizeService.GetSimSizes(name);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("simMultiples")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SimMultipleDto>>>>
            GetSimMultiples(string? name = null)
        {
            // Get response from service
            var response = await _simMultipleService.GetSimMultiples(name);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("bodyFormFactors")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<BodyFormFactorDto>>>>
            GetBodyFormFactors(string? name = null)
        {
            // Get response from service
            var response = await _bodyFormFactorService.GetBodyFormFactors(name);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
