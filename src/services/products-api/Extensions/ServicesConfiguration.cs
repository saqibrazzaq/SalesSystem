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

            // Add Services
            services.AddScoped<CategoryService>();
            services.AddScoped<ResetService>();
        }
    }
}
