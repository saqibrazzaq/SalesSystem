using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class PhoneCameraService : IPhoneCameraService
    {
        private readonly IPhoneCameraRepository _repo;
        private readonly ILogger<PhoneCameraService> _logger;

        public PhoneCameraService(IPhoneCameraRepository phoneCameraRepo, 
            ILogger<PhoneCameraService> logger)
        {
            _repo = phoneCameraRepo;
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
                response = response.GetFailureResponse("PhoneCamera count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneCameraDto>> Add(
            PhoneCameraCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneCameraDto>();

            try
            {
                // Create model from dto
                var phoneCamera = new PhoneCamera 
                {
                    PhoneId = dto.PhoneId,
                    CameraTypeId = dto.CameraTypeId,
                    Position = dto.Position,
                    FNumber = dto.FNumber,
                    FocalLength_mm = dto.FocalLength_mm,
                    LensTypeId = dto.LensTypeId,
                    OIS = dto.OIS,
                    PixelSize_um = dto.PixelSize_um,
                    Resolution_MP = dto.Resolution_MP,
                    SensorSize = dto.SensorSize
                };

                // Add in repository
                _repo.Add(phoneCamera);
                _repo.Save();

                // Set data
                response.Data = phoneCamera.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("PhoneCamera create service failed.");
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
                // Get PhoneCamera
                var phoneCamera = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (phoneCamera == null) 
                {
                    response = response.GetFailureResponse("PhoneCamera not found.");
                }
                else
                {
                    // PhoneCamera found, delete it
                    _repo.Remove(phoneCamera);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("PhoneCamera delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneCameraDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<PhoneCameraDto>();

            try
            {
                // Get PhoneCamera
                var phoneCamera = _repo.GetAll()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (phoneCamera == null) response = response.GetFailureResponse("PhoneCamera not found");
                else response.Data = phoneCamera.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("PhoneCamera service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<PhoneCameraDto>>> GetAllByPhone(Guid phoneId)
        {
            // Create new response
            var response = new ServiceResponse<List<PhoneCameraDto>>();

            try
            {
                // Get all PhoneCamera
                var phoneCameras = _repo.GetAll(
                    filter: x => x.PhoneId == phoneId,
                    orderBy: o => o.OrderByDescending(x => x.Resolution_MP));
                // Create Dtos
                var phoneCamerasDtos = new List<PhoneCameraDto>();
                foreach (var phoneCamera in phoneCameras)
                {
                    phoneCamerasDtos.Add(phoneCamera.AsDto());
                }
                // Set data
                response.Data = phoneCamerasDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("PhoneCamera service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneCameraDto>> Update(
            Guid id, PhoneCameraUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneCameraDto>();

            try
            {
                // Get PhoneCamera
                var phoneCamera = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (phoneCamera == null)
                {
                    response = response.GetFailureResponse("PhoneCamera not found.");
                }
                else
                {
                    // PhoneCamera found, update it
                    phoneCamera.FNumber = dto.FNumber;
                    phoneCamera.FocalLength_mm = dto.FocalLength_mm;
                    phoneCamera.Resolution_MP = dto.Resolution_MP;
                    phoneCamera.OIS = dto.OIS;
                    phoneCamera.PixelSize_um = dto.PixelSize_um;
                    phoneCamera.SensorSize = dto.SensorSize;
                    phoneCamera.Position = dto.Position;
                    phoneCamera.UpdatedOn = DateTime.UtcNow;
                    
                    // Save in repository
                    _repo.Update(phoneCamera);
                    _repo.Save();
                    // Set data
                    response.Data = phoneCamera.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("PhoneCamera update service failed.");
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
