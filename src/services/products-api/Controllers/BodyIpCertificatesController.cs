using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using System.Net;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BodyIpCertificatesController : ControllerBase
    {
        private readonly IBodyIpCertificateService _bodyIpCertificateService;

        public BodyIpCertificatesController(IBodyIpCertificateService bodyIpCertificateService)
        {
            _bodyIpCertificateService = bodyIpCertificateService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BodyIpCertificateDto>>>>
            GetAll()
        {
            // Get response from service
            var response = await _bodyIpCertificateService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ServiceResponse<List<BodyIpCertificateDto>>>>
            Get(Guid id)
        {
            // Get response from service
            var response = await _bodyIpCertificateService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BodyIpCertificateDto>>> Add(
            [FromBody]BodyIpCertificateCreateDto dto)
        {
            // Get response from service
            var response = await _bodyIpCertificateService.Add(dto);

            // Send response
            return response.Success 
                ? CreatedAtRoute(nameof(Get), new { response.Data.Id }, response.Data) 
                : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BodyIpCertificateDto>>> Update(
            Guid id, [FromBody]BodyIpCertificateUpdateDto dto)
        {
            // Get response from service
            var response = await _bodyIpCertificateService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _bodyIpCertificateService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
