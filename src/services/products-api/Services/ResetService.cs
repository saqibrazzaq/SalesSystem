using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using products_api.Services.Interfaces;
using System.Text.Json;

namespace products_api.Services
{
    public class ResetService
    {
        private readonly ILogger<ResetService> _logger;

        private readonly string _dataFolderName = "SeedData";
        private readonly string categoriesFile = "default-categories.json";
        private readonly string brandsFile = "default-brands.json";
        private readonly string availabilityFile = "default-availability.json";
        private readonly string networkFile = "default-networks.json";
        private readonly string networkDetailsFile = "default-network-bands.json";
        private readonly string simSizeFile = "default-sim-size.json";
        private readonly string simMultipleFile = "default-sim-multiple.json";
        private readonly string formFactorFile = "default-formfactor.json";
        private readonly string ipCertificateFile = "default-ipcertificate.json";
        private readonly string backMaterialFile = "default-backmaterial.json";
        private readonly string frameMaterialFile = "default-framematerial.json";
        private readonly string osFile = "default-os.json";
        private readonly string osVersionFile = "default-osversion.json";
        private readonly string chipsetFile = "default-chipset.json";
        private readonly string cardSlotFile = "default-cardslot.json";
        private readonly string displayTechnologyFile = "default-display-technology.json";
        private readonly string cameraFile = "default-camera-types.json";
        private readonly string fingerprintFile = "default-fingerprint.json";
        private readonly string wifiFile = "default-wifi.json";
        private readonly string bluetoothFile = "default-bluetooth.json";
        private readonly string removableBatteryFile = "default-removable-battery.json";
        private readonly string resolutionFile = "default-resolution.json";
        private readonly string gpuFile = "default-gpu.json";
        private readonly string lensTypeFile = "default-lens-types.json";
        private readonly string phoneFile = "default-phone.json";

        public string DataFolder
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _dataFolderName);
            }
        }

        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IAvailabilityService availabilityService;
        private readonly INetworkBandService networkBandService;
        private readonly INetworkService networkService;
        private readonly ISimSizeService simSizeService;
        private readonly ISimMultipleService simMultipleService;
        private readonly IFormFactorService formFactorService;
        private readonly IIpCertificateService ipCertificateService;
        private readonly IBackMaterialService backMaterialService;
        private readonly IFrameMaterialService frameMaterialService;
        private readonly IOSVersionService osVersionService;
        private readonly IOSService osService;
        private readonly IChipsetService chipsetService;
        private readonly ICardSlotService cardSlotService;
        private readonly IDisplayTechnologyService displayTechnologyService;
        private readonly ICameraTypeService cameraTypeService;
        private readonly IFingerprintService fingerprintService;
        private readonly IWifiService wifiService;
        private readonly IBluetoothService bluetoothService;
        private readonly IRemovableBatteryService removableBatteryService;
        private readonly IResolutionService resolutionService;
        private readonly IGPUService gpuService;
        private readonly ILensTypeService lensTypeService;
        private readonly IPhoneService phoneService;
        //private readonly iphonenet

        public ResetService(ILogger<ResetService> logger,
            ICategoryService categoryService,
            IBrandService brandService,
            IAvailabilityService availabilityService,
            INetworkBandService networkBandService,
            INetworkService networkService,
            ISimSizeService simSizeService,
            ISimMultipleService simMultipleService,
            IFormFactorService formFactorService,
            IIpCertificateService ipCertificateService,
            IBackMaterialService backMaterialService,
            IFrameMaterialService frameMaterialService,
            IOSVersionService osVersionService,
            IOSService osService,
            IChipsetService chipsetService,
            ICardSlotService cardSlotService,
            IDisplayTechnologyService displayTechnologyService,
            ICameraTypeService cameraTypeService,
            IFingerprintService fingerprintService,
            IWifiService wifiService,
            IBluetoothService bluetoothService,
            IRemovableBatteryService removableBatteryService,
            IResolutionService resolutionService,
            IGPUService gpuService,
            ILensTypeService lensTypeService, 
            IPhoneService phoneService)
        {
            _logger = logger;
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.availabilityService = availabilityService;
            this.networkBandService = networkBandService;
            this.networkService = networkService;
            this.simSizeService = simSizeService;
            this.simMultipleService = simMultipleService;
            this.formFactorService = formFactorService;
            this.ipCertificateService = ipCertificateService;
            this.backMaterialService = backMaterialService;
            this.frameMaterialService = frameMaterialService;
            this.osVersionService = osVersionService;
            this.osService = osService;
            this.chipsetService = chipsetService;
            this.cardSlotService = cardSlotService;
            this.displayTechnologyService = displayTechnologyService;
            this.cameraTypeService = cameraTypeService;
            this.fingerprintService = fingerprintService;
            this.wifiService = wifiService;
            this.bluetoothService = bluetoothService;
            this.removableBatteryService = removableBatteryService;
            this.resolutionService = resolutionService;
            this.gpuService = gpuService;
            this.lensTypeService = lensTypeService;
            this.phoneService = phoneService;
        }

        public async Task<ServiceResponse<string>> ResetData()
        {
            try
            {
                // Get result
                string message = string.Empty;

                message += await DeleteAllData();
                message += await SeedAllData();

                // Create response
                var response = new ServiceResponse<string>()
                {
                    Data = message,
                    Success = true,
                    Message = "Data reset done successfully."
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<string>()
                {
                    Data = null,
                    Success = false,
                    Message = "Reset service failed."
                };
            }
        }

        private async Task<string> SeedAllData()
        {
            string message = "Seeding data... ";

            message += await SeedCategories();
            message += await SeedBrands();
            message += await SeedAvailability();
            message += await SeedNetwork();
            message += await SeedNetworkBands();
            message += await SeedSimSize();
            message += await SeedSimMultiple();
            message += await SeedBodyFormFactor();
            message += await SeedBodyIpCertificate();
            message += await SeedBackMaterial();
            message += await SeedFrameMaterial();
            message += await SeedOS();
            message += await SeedOSVersion();
            message += await SeedChipset();
            message += await SeedCardSlot();
            message += await SeedDisplayTechnology();
            message += await SeedCamera();
            message += await SeedFingerprint();
            message += await SeedWifi();
            message += await SeedBluetooth();
            message += await SeedRemovableBattery();
            message += await SeedResolution();
            message += await SeedGPU();
            message += await SeedLensType();
            message += await SeedPhone();

            return message;
        }

        private async Task<string> SeedPhone()
        {
            string entityName = " phone. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, phoneFile));
            IEnumerable<PhoneSeedModel>? entities = JsonSerializer
                .Deserialize<IEnumerable<PhoneSeedModel>>(jsonData);

            if (entities == null) return $"0 {entityName}";

            foreach (var seedModel in entities)
            {
                // Convert seed model to create dto
                var createDto = await ConvertPhoneSeedModelToDto(seedModel);
                // Add phone
                var createRes = await phoneService.Add(createDto);
                // If phone is added, add other details
                if (createRes.Success == true)
                {
                    await AddPhoneCameras(createRes.Data.Id, seedModel.PhoneCameras);
                }
            }

            return entities.Count() + entityName;
        }

        private async Task AddPhoneCameras(Guid id, List<PhoneSeedModel.PhoneCameraSeedModel>? phoneCameras)
        {
            // Read all cameras in the seed model
            foreach (var cameraSeedModel in phoneCameras)
            {
                // Create phone camera dto from seed model
                var dto = new PhoneCameraCreateDto
                {
                    FNumber = cameraSeedModel.FNumber,
                    FocalLength_mm = cameraSeedModel.FocalLength_mm,
                    OIS = cameraSeedModel.OIS,
                    PixelSize_um = cameraSeedModel.PixelSize_um,
                    Resolution_MP = cameraSeedModel.Resolution_MP,
                    Position = cameraSeedModel.Position,
                    SensorSize = cameraSeedModel.SensorSize
                };
                // Find camera type
                var cameraTypeId = await CreateOrFindCameraType(cameraSeedModel.CameraTypeName);
                dto.LensTypeId = await CreateOrFindLensType(cameraSeedModel.LensTypeName);
                // Only add, if camera type is found
                if (cameraTypeId != null)
                {
                    dto.CameraTypeId = cameraTypeId ?? default;
                    await phoneService.AddCamera(id, dto);
                }
                
            }
        }

        private async Task<Guid?> CreateOrFindLensType(string lensTypeName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(lensTypeName)) return null;

            // Find entity
            var entity = await lensTypeService.GetByName(lensTypeName);
            // found, return id
            if (entity.Success == true) return entity.Data.Id;
            else
            {
                // Create new entity
                entity = await lensTypeService.Add(new LensTypeCreateDto { Name = lensTypeName });
                if (entity.Success == true) return entity.Data.Id;
                else return null;
            }
        }

        private async Task<Guid?> CreateOrFindCameraType(string cameraTypeName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(cameraTypeName)) return null;

            // Find entity
            var entity = await cameraTypeService.GetByName(cameraTypeName);
            // found, return id
            if (entity.Success == true) return entity.Data.Id;
            else
            {
                // Create new entity
                entity = await cameraTypeService.Add(new CameraTypeCreateDto { Name = cameraTypeName });
                if (entity.Success == true) return entity.Data.Id;
                else return null;
            }
        }

        private async Task<PhoneCreateDto> ConvertPhoneSeedModelToDto(PhoneSeedModel c)
        {
            // Copy simple values
            var createDto = new PhoneCreateDto
            {
                Name = c.Name,
                BatteryCapacity_mAh = c.BatteryCapacity_mAh,
                CpuCores = c.CpuCores,
                CpuDetails = c.CpuDetails,
                DisplaySize_in = c.DisplaySize_in,
                Height_mm = c.Height_mm,
                RAM_bytes = c.RAM_bytes,
                Storage_bytes = c.Storage_bytes,
                Thickness_mm = c.Thickness_mm,
                Weight_grams = c.Weight_grams,
                Width_mm = c.Width_mm
            };

            // Get IDs from string values for foreign keys
            createDto.OSId = await CreateOrFindOS(c.OSName);
            createDto.OSVersionId = await CreateOrFindOSVersion(c.OSVersionName);
            createDto.SDCardSlotId = await CreateOrFindSDCardSlot(c.SDCardSlotName);
            createDto.ChipsetId = await CreateOrFindChipset(c.ChipsetName);
            createDto.GPUId = await CreateOrFindGPU(c.GPUName);

            return createDto;
        }

        private async Task<Guid?> CreateOrFindGPU(string gPUName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(gPUName)) return null;

            // Find entity
            var entity = await gpuService.GetByName(gPUName);
            // found, return id
            if (entity.Success == true) return entity.Data.Id;
            else
            {
                // Create new entity
                entity = await gpuService.Add(new GPUCreateDto { Name = gPUName });
                if (entity.Success == true) return entity.Data.Id;
                else return null;
            }
        }

        private async Task<Guid?> CreateOrFindChipset(string chipsetName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(chipsetName)) return null;

            // Find entity
            var entity = await chipsetService.GetByName(chipsetName);
            // found, return id
            if (entity.Success == true) return entity.Data.Id;
            else
            {
                // Create new entity
                entity = await chipsetService.Add(new ChipsetCreateDto { Name = chipsetName });
                if (entity.Success == true) return entity.Data.Id;
                else return null;
            }
        }

        private async Task<Guid?> CreateOrFindSDCardSlot(string sDCardSlotName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(sDCardSlotName)) return null;

            // Find OS
            var os = await cardSlotService.GetByName(sDCardSlotName);
            // OS found, return id
            if (os.Success == true) return os.Data.Id;
            else
            {
                // Create new OS
                os = await cardSlotService.Add(new CardSlotCreateDto { Name = sDCardSlotName });
                if (os.Success == true) return os.Data.Id;
                else return null;
            }
        }

        private async Task<Guid?> CreateOrFindOSVersion(string oSVersionName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(oSVersionName)) return null;

            // Find OS
            var os = await osVersionService.GetByName(oSVersionName);
            // OS found, return id
            if (os.Success == true) return os.Data.Id;
            else
            {
                // Create new OS
                os = await osVersionService.Add(new OSVersionCreateDto { Name = oSVersionName });
                if (os.Success == true) return os.Data.Id;
                else return null;
            }
        }

        private async Task<Guid?> CreateOrFindOS(string oSName)
        {
            // Check for empty
            if (string.IsNullOrWhiteSpace(oSName)) return null;

            // Find OS
            var os = await osService.GetByName(oSName);
            // OS found, return id
            if (os.Success == true) return os.Data.Id;
            else
            {
                // Create new OS
                os = await osService.Add(new OSCreateDto { Name = oSName });
                if (os.Success == true) return os.Data.Id;
                else return null;
            }
        }

        private async Task<string> SeedLensType()
        {
            string entityName = " lensType. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, lensTypeFile));
            IEnumerable<LensTypeCreateDto>? defaultLensTypes = JsonSerializer
                .Deserialize<IEnumerable<LensTypeCreateDto>>(jsonData);

            if (defaultLensTypes == null) return $"0 {entityName}";

            foreach (var lensType in defaultLensTypes)
            {
                await lensTypeService.Add(lensType);
            }

            return defaultLensTypes.Count() + entityName;
        }

        private async Task<string> SeedGPU()
        {
            string entityName = " gpu. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, gpuFile));
            IEnumerable<GPUCreateDto>? defaultGPUs = JsonSerializer
                .Deserialize<IEnumerable<GPUCreateDto>>(jsonData);

            if (defaultGPUs == null) return $"0 {entityName}";

            foreach (var gpu in defaultGPUs)
            {
                await gpuService.Add(gpu);
            }

            return defaultGPUs.Count() + entityName;
        }

        private async Task<string> SeedResolution()
        {
            string entityName = " resolution. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, resolutionFile));
            IEnumerable<ResolutionCreateDto>? defaultResolutions = JsonSerializer
                .Deserialize<IEnumerable<ResolutionCreateDto>>(jsonData);

            if (defaultResolutions == null) return $"0 {entityName}";

            foreach (var resolution in defaultResolutions)
            {
                await resolutionService.Add(resolution);
            }

            return defaultResolutions.Count() + entityName;
        }

        private async Task<string> SeedRemovableBattery()
        {
            string entityName = " removableBattery. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, removableBatteryFile));
            IEnumerable<RemovableBatteryCreateDto>? defaultRemovableBatteries = JsonSerializer
                .Deserialize<IEnumerable<RemovableBatteryCreateDto>>(jsonData);

            if (defaultRemovableBatteries == null) return $"0 {entityName}";

            foreach (var removableBattery in defaultRemovableBatteries)
            {
                await removableBatteryService.Add(removableBattery);
            }

            return defaultRemovableBatteries.Count() + entityName;
        }

        private async Task<string> SeedBluetooth()
        {
            string entityName = " bluetooth. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, bluetoothFile));
            IEnumerable<BluetoothCreateDto>? defaultBluetooths = JsonSerializer
                .Deserialize<IEnumerable<BluetoothCreateDto>>(jsonData);

            if (defaultBluetooths == null) return $"0 {entityName}";

            foreach (var bluetooth in defaultBluetooths)
            {
                await bluetoothService.Add(bluetooth);
            }

            return defaultBluetooths.Count() + entityName;
        }

        private async Task<string> SeedWifi()
        {
            string entityName = " wifi. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, wifiFile));
            IEnumerable<WifiCreateDto>? defaultWifis = JsonSerializer
                .Deserialize<IEnumerable<WifiCreateDto>>(jsonData);

            if (defaultWifis == null) return $"0 {entityName}";

            foreach (var wifi in defaultWifis)
            {
                await wifiService.Add(wifi);
            }

            return defaultWifis.Count() + entityName;
        }

        private async Task<string> SeedFingerprint()
        {
            string entityName = " fingerprint. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, fingerprintFile));
            IEnumerable<FingerprintCreateDto>? defaultFingerprints = JsonSerializer
                .Deserialize<IEnumerable<FingerprintCreateDto>>(jsonData);

            if (defaultFingerprints == null) return $"0 {entityName}";

            foreach (var fingerprint in defaultFingerprints)
            {
                await fingerprintService.Add(fingerprint);
            }

            return defaultFingerprints.Count() + entityName;
        }

        private async Task<string> SeedCamera()
        {
            string entityName = " cameraType. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, cameraFile));
            IEnumerable<CameraTypeCreateDto>? defaultCameras = JsonSerializer
                .Deserialize<IEnumerable<CameraTypeCreateDto>>(jsonData);

            if (defaultCameras == null) return $"0 {entityName}";

            foreach (var camera in defaultCameras)
            {
                await cameraTypeService.Add(camera);
            }

            return defaultCameras.Count() + entityName;
        }

        private async Task<string> SeedDisplayTechnology()
        {
            string entityName = " displayTechnology. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, displayTechnologyFile));
            IEnumerable<DisplayTechnologyCreateDto>? defaultDisplayTechnologies = JsonSerializer
                .Deserialize<IEnumerable<DisplayTechnologyCreateDto>>(jsonData);

            if (defaultDisplayTechnologies == null) return $"0 {entityName}";

            foreach (var displayTechnology in defaultDisplayTechnologies)
            {
                await displayTechnologyService.Add(displayTechnology);
            }

            return defaultDisplayTechnologies.Count() + entityName;
        }

        private async Task<string> SeedCardSlot()
        {
            string entityName = " cardSlot. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, cardSlotFile));
            IEnumerable<CardSlotCreateDto>? defaultCardSlots = JsonSerializer
                .Deserialize<IEnumerable<CardSlotCreateDto>>(jsonData);

            if (defaultCardSlots == null) return $"0 {entityName}";

            foreach (var cardSlot in defaultCardSlots)
            {
                await cardSlotService.Add(cardSlot);
            }

            return defaultCardSlots.Count() + entityName;
        }

        private async Task<string> SeedChipset()
        {
            string entityName = " chipset. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, chipsetFile));
            IEnumerable<ChipsetCreateDto>? defaultChipsets = JsonSerializer
                .Deserialize<IEnumerable<ChipsetCreateDto>>(jsonData);

            if (defaultChipsets == null) return $"0 {entityName}";

            foreach (var chipset in defaultChipsets)
            {
                await chipsetService.Add(chipset);
            }

            return defaultChipsets.Count() + entityName;
        }

        private async Task<string> SeedOSVersion()
        {
            string entityName = " osVersion. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, osVersionFile));
            IEnumerable<OSVersionSeedModel>? defaultOSSeedList = JsonSerializer
                .Deserialize<IEnumerable<OSVersionSeedModel>>(jsonData);

            if (defaultOSSeedList == null) return $"0 {entityName}";

            int osAddedCount = 0;
            foreach (var osVersionSeed in defaultOSSeedList)
            {
                // Create new OS or find it by name
                var os = await createOS(osVersionSeed.OSName);
                var createResponse = await osVersionService.Add(
                    new OSVersionCreateDto { Name = osVersionSeed.Name, OsId = os.Id});
                if (createResponse.Success == true) osAddedCount++;
            }

            return osAddedCount + entityName;
        }

        private async Task<OSDto> createOS(string oSName)
        {
            // Create empty dto
            OSDto dto;

            // Find os
            var findResponse = await osService.GetByName(oSName);
            if (findResponse.Success == true)
                dto = findResponse.Data;
            else
            {
                var createResponse = await osService.Add(new OSCreateDto { Name = oSName });
                dto = createResponse.Data;
            }
            return dto;
        }

        private async Task<string> SeedOS()
        {
            string entityName = " os. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, osFile));
            IEnumerable<OSCreateDto>? defaultOSes = JsonSerializer
                .Deserialize<IEnumerable<OSCreateDto>>(jsonData);

            if (defaultOSes == null) return $"0 {entityName}";

            foreach (var os in defaultOSes)
            {
                await osService.Add(os);
            }

            return defaultOSes.Count() + entityName;
        }

        private async Task<string> SeedFrameMaterial()
        {
            string entityName = " frameMaterial. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, frameMaterialFile));
            IEnumerable<FrameMaterialCreateDto>? defaultFrameMaterials = JsonSerializer
                .Deserialize<IEnumerable<FrameMaterialCreateDto>>(jsonData);

            if (defaultFrameMaterials == null) return $"0 {entityName}";

            foreach (var frameMaterial in defaultFrameMaterials)
            {
                await frameMaterialService.Add(frameMaterial);
            }

            return defaultFrameMaterials.Count() + entityName;
        }

        private async Task<string> SeedBackMaterial()
        {
            string entityName = " backMaterial. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, backMaterialFile));
            IEnumerable<BackMaterialCreateDto>? defaultBackMaterials = JsonSerializer
                .Deserialize<IEnumerable<BackMaterialCreateDto>>(jsonData);

            if (defaultBackMaterials == null) return $"0 {entityName}";

            foreach (var backMaterial in defaultBackMaterials)
            {
                await backMaterialService.Add(backMaterial);
            }

            return defaultBackMaterials.Count() + entityName;
        }

        private async Task<string> SeedBodyIpCertificate()
        {
            string entityName = " ipCertificate. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, ipCertificateFile));
            IEnumerable<IpCertificateCreateDto>? DefaultBodyIpCertificates = JsonSerializer
                .Deserialize<IEnumerable<IpCertificateCreateDto>>(jsonData);

            if (DefaultBodyIpCertificates == null) return $"0 {entityName}";

            foreach (var bodyIpCertificate in DefaultBodyIpCertificates)
            {
                await ipCertificateService.Add(bodyIpCertificate);
            }

            return DefaultBodyIpCertificates.Count() + entityName;
        }

        private async Task<string> SeedBodyFormFactor()
        {
            string entityName = " formFactor. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, formFactorFile));
            IEnumerable<FormFactorCreateDto>? DefaultBodyFormFactors = JsonSerializer
                .Deserialize<IEnumerable<FormFactorCreateDto>>(jsonData);

            if (DefaultBodyFormFactors == null) return $"0 {entityName}";

            foreach (var bodyFormFactor in DefaultBodyFormFactors)
            {
                await formFactorService.Add(bodyFormFactor);
            }

            return DefaultBodyFormFactors.Count() + entityName;
        }

        private async Task<string> SeedSimMultiple()
        {
            string entityName = " simMultiple. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, simMultipleFile));
            IEnumerable<SimMultipleCreateDto>? DefaultSimMultiples = JsonSerializer
                .Deserialize<IEnumerable<SimMultipleCreateDto>>(jsonData);

            if (DefaultSimMultiples == null) return $"0 {entityName}";

            foreach (var simMultiple in DefaultSimMultiples)
            {
                await simMultipleService.Add(simMultiple);
            }

            return DefaultSimMultiples.Count() + entityName;
        }

        private async Task<string> SeedSimSize()
        {
            string entityName = " simSize. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, simSizeFile));
            IEnumerable<SimSizeCreateDto>? DefaultSimSizes = JsonSerializer
                .Deserialize<IEnumerable<SimSizeCreateDto>>(jsonData);

            if (DefaultSimSizes == null) return $"0 {entityName}";

            foreach (var simSize in DefaultSimSizes)
            {
                await simSizeService.Add(simSize);
            }

            return DefaultSimSizes.Count() + entityName;
        }

        private async Task<string> SeedAvailability()
        {
            string entityName = " availability. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, availabilityFile));
            IEnumerable<AvailabilityCreateDto>? defaultEntities = JsonSerializer
                .Deserialize<IEnumerable<AvailabilityCreateDto>>(jsonData);

            if (defaultEntities == null) return $"0 {entityName}";

            foreach (var entity in defaultEntities)
            {
                await availabilityService.Add(entity);
            }

            return defaultEntities.Count() + entityName;
        }

        private async Task<string> SeedBrands()
        {
            string entityName = " brand. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, brandsFile));
            IEnumerable<BrandCreateDto>? defaultEntities = JsonSerializer
                .Deserialize<IEnumerable<BrandCreateDto>>(jsonData);

            if (defaultEntities == null) return $"0 {entityName}";

            foreach (var entity in defaultEntities)
            {
                await brandService.Add(entity);
            }

            return defaultEntities.Count() + entityName;
        }

        private async Task<string> SeedCategories()
        {
            string entityName = " category. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, categoriesFile));
            IEnumerable<CategoryCreateDto>? defaultEntities = JsonSerializer
                .Deserialize<IEnumerable<CategoryCreateDto>>(jsonData);

            if (defaultEntities == null) return $"0 {entityName}";

            foreach (var entity in defaultEntities)
            {
                await categoryService.Add(entity);
            }

            return defaultEntities.Count() + entityName;
        }

        private async Task<string> SeedNetwork()
        {
            string entityName = " network. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, networkFile));
            IEnumerable<NetworkCreateDto>? defaultEntities =
                JsonSerializer.Deserialize<IEnumerable<NetworkCreateDto>>(jsonData);

            if (defaultEntities == null) return $"0 {entityName}";

            foreach (var entity in defaultEntities)
            {
                await networkService.Add(entity);
            }

            return defaultEntities.Count() + entityName;
        }

        private async Task<string> SeedNetworkBands()
        {
            string entityName = " networkBand. ";
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, networkDetailsFile));
            IEnumerable<NetworkBandSeedModel>? defaultEntities =
                JsonSerializer.Deserialize<IEnumerable<NetworkBandSeedModel>>(jsonData);

            if (defaultEntities == null) return $"0 {entityName}";

            // Loop through each network detail seed model
            foreach (var entity in defaultEntities)
            {
                // Create network if it does not exists, otherwise find existing by name
                var network = await createNetwork(entity.NetworkName);
                
                // Create network detail Model (table)
                var networkDetail = new NetworkBandCreateDto()
                {
                    Name = entity.Name,
                    NetworkId = network.Id
                };
                networkBandService.Add(networkDetail);
            }

            return defaultEntities.Count() + entityName;
        }

        private async Task<NetworkDto> createNetwork(string networkName)
        {
            // Create empty dto
            NetworkDto dto;
            // Find network name
            var response = await networkService.GetByName(networkName);
            if (response.Success == true)
                dto = response.Data;
            else
            {
                var createResponse = await networkService.Add(new NetworkCreateDto { Name = networkName });
                dto = createResponse.Data;
            }
            return dto;
        }

        private async Task<string> DeleteAllData()
        {
            string message = "Deleting all data... ";

            var del = await phoneService.DeleteAll();
            message += del.Data + " phone. ";

            del = await categoryService.DeleteAll();
            message += del.Data + " category. ";

            del = await brandService.DeleteAll();
            message += del.Data + " brand. ";

            del = await availabilityService.DeleteAll();
            message += del.Data + " availability. ";

            del = await networkBandService.DeleteAll();
            message += del.Data + " networkBand. ";

            del = await networkService.DeleteAll();
            message += del.Data + " network. ";

            del = await simSizeService.DeleteAll();
            message += del.Data + " simSize. ";

            del = await simMultipleService.DeleteAll();
            message += del.Data + " simMultiple. ";

            del = await formFactorService.DeleteAll();
            message += del.Data + " formFactor. ";

            del = await ipCertificateService.DeleteAll();
            message += del.Data + " ipCertificate. ";

            del = await backMaterialService.DeleteAll();
            message += del.Data + " backMaterial. ";

            del = await frameMaterialService.DeleteAll();
            message += del.Data + " frameMaterial. ";

            del = await osVersionService.DeleteAll();
            message += del.Data + " osVersion. ";

            del = await osService.DeleteAll();
            message += del.Data + " os. ";

            del = await chipsetService.DeleteAll();
            message += del.Data + " chipset. ";

            del = await cardSlotService.DeleteAll();
            message += del.Data + " cardSlot. ";

            del = await displayTechnologyService.DeleteAll();
            message += del.Data + " displayTechnology. ";

            del = await cameraTypeService.DeleteAll();
            message += del.Data + " cameraType. ";

            del = await fingerprintService.DeleteAll();
            message += del.Data + " fingerPrint. ";

            del = await wifiService.DeleteAll();
            message += del.Data + " wifi. ";

            del = await bluetoothService.DeleteAll();
            message += del.Data + " bluetooth. ";

            del = await removableBatteryService.DeleteAll();
            message += del.Data + " removableBattery. ";

            del = await resolutionService.DeleteAll();
            message += del.Data + " resolution. ";

            del = await gpuService.DeleteAll();
            message += del.Data + " gpu. ";

            del = await lensTypeService.DeleteAll();
            message += del.Data + " lensType. ";

            del = await phoneService.DeleteAll();
            message += del.Data + " phone. ";
            
            message += "Delete complete. ";

            return message;
        }
    }
}
