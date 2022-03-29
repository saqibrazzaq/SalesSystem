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
        private readonly ILogger<ListingController> _logger;

        public ListingController(ListingService listingService, 
            ILogger<ListingController> logger)
        {
            _listingService = listingService;
            _logger = logger;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<BrandDto>>>> 
            GetBrands()
        {
            // Create response
            var response = new ServiceResponse<IEnumerable<BrandDto>>();
            try
            {
                // Get brands from service
                var result = await _listingService.GetBrands();
                if (result == null)
                    response = response.GetFailureResponse("Brand Service failed.");
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Brand Service failed.");
            }
            
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("availabilities")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AvailabilityDto>>>> 
            GetAvailabilities()
        {
            // Create response
            var response = new ServiceResponse<IEnumerable<AvailabilityDto>>();
            try
            {
                // Get availabilities from service
                var result = await _listingService.GetAvailabilities();
                if (result == null)
                    response = response.GetFailureResponse("Availability Service failed.");
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Availability Service failed.");
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("networks")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<NetworkDto>>>>
            GetNetworks()
        {
            // Create response
            var response = new ServiceResponse<IEnumerable<NetworkDto>>();
            try
            {
                // Get Networks from service
                var result = await _listingService.GetNetworks();
                if (result == null)
                    response = response.GetFailureResponse("Network Service failed.");
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Service failed.");
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("networkBands")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<NetworkBandDto>>>>
            GetNetworkBands(string networkName)
        {
            // Create response
            var response = new ServiceResponse<IEnumerable<NetworkBandDto>>();
            try
            {
                // Get Network Bands from service
                var result = await _listingService.GetNetworkBands(networkName);
                if (result == null)
                    response = response.GetFailureResponse("Network Band Service failed.");
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Network Band Service failed.");
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("simSizes")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SimSizeDto>>>>
            GetSimSizes()
        {
            // Create response
            var response = new ServiceResponse<IEnumerable<SimSizeDto>>();
            try
            {
                // Get SimSize from service
                var result = await _listingService.GetSimSizes();
                if (result == null)
                    response = response.GetFailureResponse("SimSize Service failed.");
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimSize Service failed.");
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("simMultiples")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SimMultipleDto>>>>
            GetSimMultiples()
        {
            // Create response
            var response = new ServiceResponse<IEnumerable<SimMultipleDto>>();
            try
            {
                // Get SimMultiple from service
                var result = await _listingService.GetSimMultiples();
                if (result == null)
                    response = response.GetFailureResponse("SimMultiple Service failed.");
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("SimMultiple Service failed.");
            }

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
