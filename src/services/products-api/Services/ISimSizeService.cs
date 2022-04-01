﻿using products_api.Dtos;

namespace products_api.Services
{
    public interface ISimSizeService
    {
        Task<ServiceResponse<SimSizeDto>> Get(Guid id);
        Task<ServiceResponse<List<SimSizeDto>>> GetAll();
        Task<ServiceResponse<SimSizeDto>> Add(SimSizeCreateDto dto);
        Task<ServiceResponse<SimSizeDto>> Update(Guid id, SimSizeUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
