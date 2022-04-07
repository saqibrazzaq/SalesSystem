using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _repo;
        private readonly IPhoneNetworkBandRepository _phoneNetworkBandRepository;
        private readonly IPhoneCameraRepository _phoneCameraRepository;
        private readonly ILogger<PhoneService> _logger;

        public PhoneService(IPhoneRepository phoneRepo,
            ILogger<PhoneService> logger, 
            IPhoneCameraRepository cameraRepository, 
            IPhoneNetworkBandRepository bandRepository)
        {
            _repo = phoneRepo;
            _logger = logger;
            _phoneCameraRepository = cameraRepository;
            _phoneNetworkBandRepository = bandRepository;
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
                response = response.GetFailureResponse("Phone count service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneDto>> Add(
            PhoneCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneDto>();

            try
            {
                // Create model from dto
                var phone = new Phone 
                { 
                    AnnouncedDate = dto.AnnouncedDate,
                    BatteryCapacity_mAh = dto.BatteryCapacity_mAh,
                    ChipsetId = dto.ChipsetId,
                    CpuCores = dto.CpuCores,
                    CpuDetails = dto.CpuDetails,
                    DisplaySize_in = dto.DisplaySize_in,
                    GPUId = dto.GPUId,
                    Height_mm = dto.Height_mm,
                    Weight_grams = dto.Weight_grams,
                    Width_mm = dto.Width_mm,
                    Name = dto.Name,
                    OSId = dto.OSId,
                    OSVersionId = dto.OSVersionId,
                    RAM_bytes = dto.RAM_bytes,
                    ReleaseDate = dto.ReleaseDate,
                    SDCardSlotId = dto.SDCardSlotId,
                    Storage_bytes = dto.Storage_bytes,
                    Thickness_mm = dto.Thickness_mm,
                };

                // Add in repository
                _repo.Add(phone);
                _repo.Save();

                // Set data
                response.Data = phone.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone create service failed.");
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
                // Get Phone
                var phone = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (phone == null) 
                {
                    response = response.GetFailureResponse("Phone not found.");
                }
                else
                {
                    // Phone found, delete it
                    _repo.Remove(phone);
                    _repo.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneDto>> Get(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<PhoneDto>();

            try
            {
                // Get Phone
                var phone = _repo.GetAll()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (phone == null) response = response.GetFailureResponse("Phone not found");
                else response.Data = phone.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<List<PhoneDto>>> GetAll()
        {
            // Create new response
            var response = new ServiceResponse<List<PhoneDto>>();

            try
            {
                // Get all Phone
                var phones = _repo.GetAll(orderBy: o => o.OrderBy(x => x.Name));
                // Create Dtos
                var phoneDtos = new List<PhoneDto>();
                foreach (var phone in phones)
                {
                    phoneDtos.Add(phone.AsDto());
                }
                // Set data
                response.Data = phoneDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneDto>> Update(
            Guid id, PhoneUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneDto>();

            try
            {
                // Get Phone
                var phone = _repo.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (phone == null)
                {
                    response = response.GetFailureResponse("Phone not found.");
                }
                else
                {
                    // Phone found, update it
                    phone.AnnouncedDate = dto.AnnouncedDate;
                    phone.CpuCores = dto.CpuCores;
                    phone.GPUId = dto.GPUId;
                    phone.OSId = dto.OSId;
                    phone.CpuCores = dto.CpuCores;
                    phone.CpuDetails = dto.CpuDetails;
                    phone.BatteryCapacity_mAh = dto.BatteryCapacity_mAh;
                    phone.ChipsetId = dto.ChipsetId;
                    phone.DisplaySize_in = dto.DisplaySize_in;
                    phone.RAM_bytes = dto.RAM_bytes;
                    phone.Height_mm = dto.Height_mm;
                    phone.Width_mm = dto.Width_mm;
                    phone.Thickness_mm = dto.Thickness_mm;
                    phone.Name = dto.Name;
                    phone.Weight_grams = dto.Weight_grams;
                    phone.SDCardSlotId = dto.SDCardSlotId;
                    
                    // Save in repository
                    _repo.Update(phone);
                    _repo.Save();
                    // Set data
                    response.Data = phone.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone update service failed.");
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
                response.Data += _phoneCameraRepository.DeleteAll();
                response.Data += _phoneNetworkBandRepository.DeleteAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Remove service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneNetworkBandDto>> AddNetworkBand(
            Guid phoneId, PhoneNetworkBandCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneNetworkBandDto>();
            try
            {
                // Create model from dto
                var model = new PhoneNetworkBand { NetworkBandId = dto.NetworkBandId, PhoneId = dto.PhoneId };
                // Add in repository
                _phoneNetworkBandRepository.Add(model);
                _phoneNetworkBandRepository.Save();

                // Set data
                response.Data = model.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Create service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> RemoveNetworkBand(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get Phone
                var entity = _phoneNetworkBandRepository.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (entity == null)
                {
                    response = response.GetFailureResponse("Not found.");
                }
                else
                {
                    // entity found, delete it
                    _phoneNetworkBandRepository.Remove(entity);
                    _phoneNetworkBandRepository.Save();
                    // Set data
                    response.Data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("delete service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneNetworkBandDto>> GetNetworkBand(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<PhoneNetworkBandDto>();

            try
            {
                // Get entity
                var entity = _phoneNetworkBandRepository.GetAll()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                // Check null
                if (entity == null) response = response.GetFailureResponse("Not found");
                else response.Data = entity.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneCameraDto>> AddCamera(Guid phoneId, PhoneCameraCreateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneCameraDto>();
            try
            {
                // Create model from dto
                var model = new PhoneCamera 
                { 
                    CameraTypeId = dto.CameraTypeId,
                    PhoneId = phoneId,
                    FNumber = dto.FNumber,
                    FocalLength_mm = dto.FocalLength_mm,
                    LensTypeId = dto.LensTypeId,
                    OIS = dto.OIS,
                    PixelSize_um = dto.PixelSize_um,
                    Position = dto.Position,
                    Resolution_MP = dto.Resolution_MP,
                    SensorSize = dto.SensorSize
                };
                // Add in repository
                _phoneCameraRepository.Add(model);
                _phoneCameraRepository.Save();

                // Set data
                response.Data = model.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Create service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<PhoneCameraDto>> UpdateCamera(Guid id, PhoneCameraUpdateDto dto)
        {
            // Create new response
            var response = new ServiceResponse<PhoneCameraDto>();

            try
            {
                // Get entity
                var entity = _phoneCameraRepository.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (entity == null)
                {
                    response = response.GetFailureResponse("Not found.");
                }
                else
                {
                    // Phone found, update it
                    entity.FNumber = dto.FNumber;
                    entity.FocalLength_mm = dto.FocalLength_mm;
                    entity.Resolution_MP = dto.Resolution_MP;
                    entity.SensorSize = dto.SensorSize;
                    entity.Position = dto.Position;
                    entity.PixelSize_um = dto.PixelSize_um;
                    entity.CameraTypeId = dto.CameraTypeId;
                    entity.LensTypeId = dto.LensTypeId;
                    entity.OIS = dto.OIS;

                    // Save in repository
                    _phoneCameraRepository.Update(entity);
                    _phoneCameraRepository.Save();
                    // Set data
                    response.Data = entity.AsDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.GetFailureResponse("Phone update service failed.");
            }

            return await Task.FromResult(response);
        }

        public async Task<ServiceResponse<bool>> RemoveCamera(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<bool>();

            string message = string.Empty;

            try
            {
                // Get PhoneCamera
                var phoneCamera = _phoneCameraRepository.GetAll(
                    filter: x => x.Id == id
                    ).FirstOrDefault();
                if (phoneCamera == null)
                {
                    response = response.GetFailureResponse("PhoneCamera not found.");
                }
                else
                {
                    // PhoneCamera found, delete it
                    _phoneCameraRepository.Remove(phoneCamera);
                    _phoneCameraRepository.Save();
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

        public async Task<ServiceResponse<List<PhoneCameraDto>>> GetAllCamerasByPhone(Guid phoneId)
        {
            // Create new response
            var response = new ServiceResponse<List<PhoneCameraDto>>();

            try
            {
                // Get all PhoneCamera
                var phoneCameras = _phoneCameraRepository.GetAll(
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

        public async Task<ServiceResponse<PhoneCameraDto>> GetCamera(Guid id)
        {
            // Create new response
            var response = new ServiceResponse<PhoneCameraDto>();

            try
            {
                // Get PhoneCamera
                var phoneCamera = _phoneCameraRepository.GetAll()
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
    }
}
