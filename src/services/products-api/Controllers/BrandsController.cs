using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Misc;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandService _brandService;

        public BrandsController(BrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<BrandSearchResult>>> Index(
            string? text = null,
            int? page = 1,
            int? pageSize = DefaultValues.PageSize,
            string? sortBy = "position",
            string? sortDirection = "asc"
            )
        {
            // Get response from repository
            var response = await _brandService.SearchBrands(text: text,
                page: page,
                pageSize: pageSize,
                sortBy: sortBy,
                sortDirection: sortDirection);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
