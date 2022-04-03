using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;
using products_api.Services.Interfaces;
using System.Net;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IpCertificatesController : ControllerBase
    {
        private readonly IIpCertificateService _ipCertificateService;

        public IpCertificatesController(IIpCertificateService bodyIpCertificateService)
        {
            _ipCertificateService = bodyIpCertificateService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IpCertificateDto>>>>
            GetAll()
        {
            // Get response from service
            var response = await _ipCertificateService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<IpCertificateDto>>>
            Get(Guid id)
        {
            // Get response from service
            var response = await _ipCertificateService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>>
            Count()
        {
            // Get response from service
            var response = await _ipCertificateService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IpCertificateDto>>> Add(
            [FromBody]IpCertificateCreateDto dto)
        {
            // Get response from service
            var response = await _ipCertificateService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<IpCertificateDto>>> Update(
            Guid id, [FromBody]IpCertificateUpdateDto dto)
        {
            // Get response from service
            var response = await _ipCertificateService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _ipCertificateService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
