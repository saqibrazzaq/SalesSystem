using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;

namespace products_api.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _repo;
        private readonly ILogger<PhoneService> _logger;

        public PhoneService(IPhoneRepository phoneRepo, 
            ILogger<PhoneService> logger)
        {
            _repo = phoneRepo;
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
