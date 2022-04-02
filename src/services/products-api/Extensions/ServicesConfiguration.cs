using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IBodyIpCertificateRepository, SqlServerBodyIpCertificateRepository>();
            services.AddScoped<IBackMaterialRepository, SqlServerBackMaterialRepository>();
            services.AddScoped<IFrameMaterialRepository, SqlServerFrameMaterialRepository>();
            services.AddScoped<IOSRepository, SqlServerOSRepository>();
            services.AddScoped<IOSVersionRepository, SqlServerOSVersionRepository>();
            services.AddScoped<IChipsetRepository, SqlServerChipsetRepository>();
            services.AddScoped<ICardSlotRepository, SqlServerCardSlotRepository>();
            services.AddScoped<IDisplayTechnologyRepository, SqlServerDisplayTechnologyRepository>();
            services.AddScoped<ICameraRepository, SqlServerCameraRepository>();
            services.AddScoped<IFingerprintRepository, SqlServerFingerprintRepository>();
            services.AddScoped<IWifiRepository, SqlServerWifiRepository>();
            services.AddScoped<IBluetoothRepository, SqlServerBluetoothRepository>();
            
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
            services.AddScoped<IBodyIpCertificateService, BodyIpCertificateService>();
            services.AddScoped<IBackMaterialService, BackMaterialService>();
            services.AddScoped<IFrameMaterialService, FrameMaterialService>();
            services.AddScoped<IOSService, OSService>();
            services.AddScoped<IOSVersionService, OSVersionService>();
            services.AddScoped<IChipsetService, ChipsetService>();
            services.AddScoped<ICardSlotService, CardSlotService>();
            services.AddScoped<IDisplayTechnologyService, DisplayTechnologyService>();
            services.AddScoped<ICameraService, CameraService>();
            services.AddScoped<IFingerprintService, FingerprintService>();
            services.AddScoped<IWifiService, WifiService>();
            services.AddScoped<IBluetoothService, BluetoothService>();
        }
    }
}
