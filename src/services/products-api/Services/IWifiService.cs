﻿using products_api.Dtos;

namespace products_api.Services
{
    public interface IWifiService
    {
        Task<ServiceResponse<List<WifiDto>>> GetAll();
        Task<ServiceResponse<WifiDto>> Get(Guid id);
        Task<ServiceResponse<WifiDto>> Add(WifiCreateDto dto);
        Task<ServiceResponse<WifiDto>> Update(Guid id, WifiUpdateDto dto);
        Task<ServiceResponse<bool>> Remove(Guid id);
        Task<ServiceResponse<int>> Count();
    }
}
