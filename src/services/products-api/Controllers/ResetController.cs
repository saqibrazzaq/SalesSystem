using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly ResetService _resetService;

        public ResetController(ResetService resetService)
        {
            _resetService = resetService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<string>>> ResetData()
        {
            // Call service
            var response = await _resetService.ResetData();

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
