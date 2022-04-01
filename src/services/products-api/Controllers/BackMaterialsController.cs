﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Dtos;
using products_api.Services;

namespace products_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BackMaterialsController : ControllerBase
    {
        private readonly IBackMaterialService _backMaterialService;

        public BackMaterialsController(IBackMaterialService backMaterialService)
        {
            _backMaterialService = backMaterialService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BackMaterialDto>>>> GetAll()
        {
            // Get response from service
            var response = await _backMaterialService.GetAll();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BackMaterialDto>>> Get(Guid id)
        {
            // Get response from service
            var response = await _backMaterialService.Get(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> Count()
        {
            // Get response from service
            var response = await _backMaterialService.Count();

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BackMaterialDto>>> Add(
            [FromBody] BackMaterialCreateDto dto)
        {
            // Get response from service
            var response = await _backMaterialService.Add(dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BackMaterialDto>>> Update(
            Guid id, [FromBody] BackMaterialUpdateDto dto)
        {
            // Get response from service
            var response = await _backMaterialService.Update(id, dto);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> Remove(Guid id)
        {
            // Get response from service
            var response = await _backMaterialService.Remove(id);

            // Send response
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
