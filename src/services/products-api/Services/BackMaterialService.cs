﻿using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;

namespace products_api.Services
{
    public class BackMaterialService : IBackMaterialService
    {
        private readonly IBackMaterialRepository _backMaterialRepo;
        private readonly ILogger<BackMaterialService> _logger;

        public BackMaterialService(IBackMaterialRepository backMaterialRepo, 
            ILogger<BackMaterialService> logger)
        {
            _backMaterialRepo = backMaterialRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _backMaterialRepo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BackMaterialDto>> Add(
            BackMaterialCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BackMaterialDto>();

            try
            {
                // Create model from dto
                var backMaterial = new BackMaterial { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _backMaterialRepo.Add(backMaterial);
                _backMaterialRepo.Save();

                // Set data
                response.Data = backMaterial.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial create service failed.");
            }
            
            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> Remove(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get BackMaterial
                var availability = _backMaterialRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (availability == null) 
                {
                    response = response.GetFailureResponse("BackMaterial not found.");
                }
                else
                {
                    // Availability found, delete it
                    _backMaterialRepo.Remove(availability);
                    _backMaterialRepo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BackMaterialDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<BackMaterialDto>();

            try
            {
                // Get BackMaterial
                var availability = _backMaterialRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (availability == null) response = response.GetFailureResponse("BackMaterial not found");
                else response.Data = availability.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<BackMaterialDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<BackMaterialDto>>();

            try
            {
                // Get all BackMaterial
                var backMaterials = _backMaterialRepo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var backMaterialDtos = new List<BackMaterialDto>();
                foreach (var backMaterial in backMaterials)
                {
                    backMaterialDtos.Add(backMaterial.AsDto());
                }
                // Set data
                response.Data = backMaterialDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<BackMaterialDto>> Update(
            Guid id, BackMaterialUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<BackMaterialDto>();

            try
            {
                // Get BackMaterial
                var backMaterial = _backMaterialRepo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (backMaterial == null)
                {
                    response = response.GetFailureResponse("BackMaterial not found.");
                }
                else
                {
                    // BackMaterial found, update it
                    backMaterial.Name = dto.Name;
                    backMaterial.Position = dto.Position;
                    
                    // Save in repository
                    _backMaterialRepo.Update(backMaterial);
                    _backMaterialRepo.Save();
                    // Set data
                    response.Data = backMaterial.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("BackMaterial update service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
