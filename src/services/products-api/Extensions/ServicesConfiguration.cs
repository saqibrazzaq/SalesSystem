﻿using Microsoft.EntityFrameworkCore;
using products_api.Data;
using products_api.Data.Repository;
using products_api.Data.SQLServerRepository;
using products_api.Services;

namespace products_api.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Add Repositories
            services.AddScoped<ICategoryRepository, SqlServerCategoryRepository>();
            services.AddScoped<IResetRepository, SqlServerResetRepository>();
            services.AddScoped<IBrandRepository, SqlServerBrandRepository>();
            services.AddScoped<IAvailabilityRepository, SqlServerAvailabilityRepository>();
            services.AddScoped<INetworkRepository, SqlServerNetworkRepository>();
            services.AddScoped<INetworkBandRepository, SqlServerNetworkBandRepository>();
            services.AddScoped<ISimSizeRepository, SqlServerSimSizeRepository>();
            services.AddScoped<ISimMultipleRepository, SqlServerSimMultipleRepository>();
            services.AddScoped<IBodyFormFactorRepository, SqlServerBodyFormFactorRepository>();
            
            // Add Services
            services.AddScoped<CategoryService>();
            services.AddScoped<ResetService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAvailabilityService, AvailabilityService>();
            services.AddScoped<INetworkService, NetworkService>();
            services.AddScoped<INetworkBandService, NetworkBandService>();
            services.AddScoped<ISimSizeService, SimSizeService>();
            services.AddScoped<ISimMultipleService, SimMultipleService>();
            services.AddScoped<IBodyFormFactorService, BodyFormFactorService>();
            services.AddScoped<ListingService>();
        }
    }
}
