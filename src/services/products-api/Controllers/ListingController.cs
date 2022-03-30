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
        private readonly ListingService _listingService;

        public ListingController(ListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<BrandDto>>>> 
            GetBrands()
        {
            // Get response from service
            var response = await _listingService.GetNetworks();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("availabilities")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AvailabilityDto>>>> 
            GetAvailabilities()
        {
            // Get response from service
            var response = await _listingService.GetAvailabilities();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("networks")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<NetworkDto>>>>
            GetNetworks()
        {
            // Get response from service
            var response = await _listingService.GetNetworks();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("networkBands")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<NetworkBandDto>>>>
            GetNetworkBands(string networkName)
        {
            // Get response from service
            var response = await _listingService.GetNetworkBands(networkName);
            
            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("simSizes")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SimSizeDto>>>>
            GetSimSizes()
        {
            // Get response from service
            var response = await _listingService.GetSimSizes();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("simMultiples")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SimMultipleDto>>>>
            GetSimMultiples()
        {
            // Get response from service
            var response = await _listingService.GetSimMultiples();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("bodyFormFactors")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<BodyFormFactorDto>>>>
            GetBodyFormFactors()
        {
            // Get response from service
            var response = await _listingService.GetBodyFormFactors();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
