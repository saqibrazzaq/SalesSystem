using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class FormFactorService : IFormFactorService
    {
        private readonly IFormFactorRepository _repo;
        private readonly ILogger<FormFactorService> _logger;

        public FormFactorService(IFormFactorRepository formFactorRepo, 
            ILogger<FormFactorService> logger)
        {
            _repo = formFactorRepo;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> Count()
        {
            // Create response
            var response = new ServiceResponse<int>();

            try
            {
                // Get count
                var count = _repo.Count();
                // Set data
                response.Data = count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FormFactor count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FormFactorDto>> Add(
            FormFactorCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<FormFactorDto>();

            try
            {
                // Create model from dto
                var formFactor = new FormFactor { Name = dto.Name, Position = dto.Position };

                // Add in repository
                _repo.Add(formFactor);
                _repo.Save();

                // Set data
                response.Data = formFactor.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FormFactor create service failed.");
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
                // Get form factor
                var formFactor = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (formFactor == null) 
                {
                    response = response.GetFailureResponse("FormFactor not found.");
                }
                else
                {
                    // form factor found, delete it
                    _repo.Remove(formFactor);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FormFactor delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FormFactorDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<FormFactorDto>();

            try
            {
                // Get all FormFactor
                var formFactor = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name))
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (formFactor == null) response = response.GetFailureResponse("form factor not found.");
                else response.Data = formFactor.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FormFactor service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<FormFactorDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<FormFactorDto>>();

            try
            {
                // Get all FormFactor
                var formFactors = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var formFactorDtos = new List<FormFactorDto>();
                foreach (var formFactor in formFactors)
                {
                    formFactorDtos.Add(formFactor.AsDto());
                }
                // Set data
                response.Data = formFactorDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FormFactor service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<FormFactorDto>> Update(
            Guid id, FormFactorUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<FormFactorDto>();

            try
            {
                // Get FormFactor
                var formFactor = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (formFactor == null)
                {
                    response = response.GetFailureResponse("FormFactor not found.");
                }
                else
                {
                    // form factor found, update it
                    formFactor.Name = dto.Name;
                    formFactor.Position = dto.Position;
                    
                    // Save in repository
                    _repo.Update(formFactor);
                    _repo.Save();
                    // Set data
                    response.Data = formFactor.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("FormFactor update service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> RemoveRange(List<Guid> ids)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            try
            {
                // Get all entities by id in the list
                var entities = _repo.GetAll(
                    filter: x => ids.Contains(x.Id)
                    ).ToArray();
                _repo.RemoveRange(entities);

                // Set data
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<int>> DeleteAll()
        {
            // Create new response
            var response = new ServiceResponse<int>();

            try
            {
                response.Data = _repo.DeleteAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }
    }
}
