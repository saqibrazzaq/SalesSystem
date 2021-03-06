using Dapper;
using products_api.Data.Repository;
using products_api.Dtos;
using products_api.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace products_api.Data.SQLServerRepository
{
    public class SqlServerResetRepository : IResetRepository
    {
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


        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly INetworkRepository _networkRepository;
        private readonly INetworkBandRepository _networkBandRepository;
        private readonly ISimSizeRepository _simSizeRepo;
        private readonly ISimMultipleRepository _simMultipleRepo;
        private readonly IFormFactorRepository _formFactorRepo;
        private readonly IIpCertificateRepository _ipCertificateRepo;
        private readonly IBackMaterialRepository _backMaterialRepository;
        private readonly IFrameMaterialRepository _frameMaterialRepository;
        private readonly IOSRepository _osRepository;
        private readonly IOSVersionRepository _osVersionRepo;
        private readonly IChipsetRepository _chipsetRepo;
        private readonly ICardSlotRepository _cardSlotRepo;
        private readonly IDisplayTechnologyRepository _displayTechnologyRepo;
        private readonly ICameraTypeRepository _cameraRepo;
        private readonly IFingerprintRepository _fingerprintRepo;
        private readonly IWifiRepository _wifiRepo;
        private readonly IBluetoothRepository _bluetoothRepo;
        private readonly IBatteryTypeRepository _removableBatteryRepo;
        private readonly IResolutionRepository _resolutionRepo;
        private readonly IGPURepository _gpuRepo;
        private readonly ILensTypeRepository _lensTypeRepo;
        // For Dapper
        private readonly IConfiguration _configuration;

        public SqlServerResetRepository(ICategoryRepository categoryRepository,
            IConfiguration configuration,
            IBrandRepository brandRepository,
            IAvailabilityRepository availabilityRepository,
            INetworkRepository networkRepository,
            INetworkBandRepository networkBandRepository,
            ISimSizeRepository simSizeRepo,
            ISimMultipleRepository simMultipleRepo,
            IFormFactorRepository bodyFormFactorRepo,
            IIpCertificateRepository bodyIpCertificateRepo,
            IBackMaterialRepository backMaterialRepository,
            IFrameMaterialRepository frameMaterialRepository,
            IOSRepository osRepository,
            IOSVersionRepository osVersionRepo,
            IChipsetRepository chipsetRepo,
            ICardSlotRepository cardSlotRepo,
            IDisplayTechnologyRepository displayTechnologyRepo,
            ICameraTypeRepository cameraRepo,
            IFingerprintRepository fingerprintRepo,
            IWifiRepository wifiRepo,
            IBluetoothRepository bluetoothRepo,
            IBatteryTypeRepository removableBatteryRepo,
            IResolutionRepository resolutionRepo,
            IGPURepository gpuRepo, 
            ILensTypeRepository lensTypeRepo)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _availabilityRepository = availabilityRepository;
            _networkRepository = networkRepository;
            _networkBandRepository = networkBandRepository;
            _simSizeRepo = simSizeRepo;
            _simMultipleRepo = simMultipleRepo;
            _formFactorRepo = bodyFormFactorRepo;
            _ipCertificateRepo = bodyIpCertificateRepo;
            _backMaterialRepository = backMaterialRepository;
            _frameMaterialRepository = frameMaterialRepository;
            _osRepository = osRepository;
            _osVersionRepo = osVersionRepo;
            _chipsetRepo = chipsetRepo;
            _cardSlotRepo = cardSlotRepo;
            _displayTechnologyRepo = displayTechnologyRepo;
            _cameraRepo = cameraRepo;
            _fingerprintRepo = fingerprintRepo;
            _wifiRepo = wifiRepo;
            _bluetoothRepo = bluetoothRepo;
            _removableBatteryRepo = removableBatteryRepo;
            _resolutionRepo = resolutionRepo;
            _gpuRepo = gpuRepo;
            _lensTypeRepo = lensTypeRepo;
        }

        public SqlConnection SqlConnection
        {
            get
            {
                return new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<string> ResetData()
        {
            string result = string.Empty;
            // Delete all data
            result += DeleteAllData();

            // Seed data
            result += SeedAllData();

            return await Task.FromResult(result);
        }

        private string SeedAllData()
        {
            string result = string.Empty;

            result += SeedCategories();
            result += SeedBrands();
            result += SeedAvailability();
            result += SeedNetwork();
            result += SeedNetworkBands();
            result += SeedSimSize();
            result += SeedSimMultiple();
            result += SeedBodyFormFactor();
            result += SeedBodyIpCertificate();
            result += SeedBackMaterial();
            result += SeedFrameMaterial();
            result += SeedOS();
            result += SeedOSVersion();
            result += SeedChipset();
            result += SeedCardSlot();
            result += SeedDisplayTechnology();
            result += SeedCamera();
            result += SeedFingerprint();
            result += SeedWifi();
            result += SeedBluetooth();
            result += SeedRemovableBattery();
            result += SeedResolution();
            result += SeedGPU();
            result += SeedLensType();

            return result;
        }

        private string SeedBrands()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, brandsFile));
            IEnumerable<Brand>? DefaultBrands = JsonSerializer
                .Deserialize<IEnumerable<Brand>>(jsonData);

            if (DefaultBrands == null) return "0 Brands Added. ";

            foreach (var brand in DefaultBrands)
            {
                _brandRepository.Add(brand);
            }
            _brandRepository.Save();

            return DefaultBrands.Count() + " Brands Added. ";
        }

        private string SeedCategories()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, categoriesFile));
            IEnumerable<Category>? DefaultCategories = JsonSerializer.Deserialize<IEnumerable<Category>>(jsonData);

            if (DefaultCategories == null) return "0 Categories Added. ";

            foreach (Category category in DefaultCategories)
            {
                _categoryRepository.Add(category);
            }
            _categoryRepository.Save();

            return DefaultCategories.Count() + " Categories Added. ";
        }

        private string SeedNetwork()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, networkFile));
            IEnumerable<Network>? DefaultNetworks = 
                JsonSerializer.Deserialize<IEnumerable<Network>>(jsonData);

            if (DefaultNetworks == null) return "0 Networks Added. ";

            foreach (var network in DefaultNetworks)
            {
                _networkRepository.Add(network);
            }
            _networkRepository.Save();

            return DefaultNetworks.Count() + " Networks Added. ";
        }

        private string SeedNetworkBands()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, networkDetailsFile));
            IEnumerable<NetworkBandSeedModel>? DefaultNetworkDetailSeeds =
                JsonSerializer.Deserialize<IEnumerable<NetworkBandSeedModel>>(jsonData);

            if (DefaultNetworkDetailSeeds == null) return "0 Network details Added. ";

            // Get all networks (parents of network detail)
            var networks = _networkRepository.GetAll();

            // Loop through each network detail seed model
            foreach (var networkDetailSeed in DefaultNetworkDetailSeeds)
            {
                // Create network detail Model (table)
                var networkDetail = new NetworkBand()
                {
                    Name = networkDetailSeed.Name,
                    NetworkId = networks
                        .Where(x => x.Name.Equals(networkDetailSeed.NetworkName))
                        .Select(x => x.Id)
                        .FirstOrDefault()
                };
                _networkBandRepository.Add(networkDetail);
            }
            _networkBandRepository.Save();

            return DefaultNetworkDetailSeeds.Count() + " Network bands Added. ";
        }

        private string SeedAvailability()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, availabilityFile));
            IEnumerable<Availability>? DefaultAvailability = JsonSerializer
                .Deserialize<IEnumerable<Availability>>(jsonData);

            if (DefaultAvailability == null) return "0 Availabilities Added. ";

            foreach (var availability in DefaultAvailability)
            {
                _availabilityRepository.Add(availability);
            }
            _availabilityRepository.Save();

            return DefaultAvailability.Count() + " Availabilities Added. ";
        }

        private string SeedSimSize()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, simSizeFile));
            IEnumerable<SimSize>? DefaultSimSizes = JsonSerializer
                .Deserialize<IEnumerable<SimSize>>(jsonData);

            if (DefaultSimSizes == null) return "0 Sim Size Added. ";

            foreach (var simSize in DefaultSimSizes)
            {
                _simSizeRepo.Add(simSize);
            }
            _simSizeRepo.Save();

            return DefaultSimSizes.Count() + " Sim Sizes Added. ";
        }

        private string SeedSimMultiple()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, simMultipleFile));
            IEnumerable<SimMultiple>? DefaultSimMultiples = JsonSerializer
                .Deserialize<IEnumerable<SimMultiple>>(jsonData);

            if (DefaultSimMultiples == null) return "0 Sim Multiple Added. ";

            foreach (var simMultiple in DefaultSimMultiples)
            {
                _simMultipleRepo.Add(simMultiple);
            }
            _simMultipleRepo.Save();

            return DefaultSimMultiples.Count() + " Sim Multiples Added. ";
        }

        private string SeedBodyFormFactor()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, formFactorFile));
            IEnumerable<FormFactor>? DefaultBodyFormFactors = JsonSerializer
                .Deserialize<IEnumerable<FormFactor>>(jsonData);

            if (DefaultBodyFormFactors == null) return "0 Body FormFactor Added. ";

            foreach (var bodyFormFactor in DefaultBodyFormFactors)
            {
                _formFactorRepo.Add(bodyFormFactor);
            }
            _formFactorRepo.Save();

            return DefaultBodyFormFactors.Count() + " Body FormFactor Added. ";
        }

        private string SeedBodyIpCertificate()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, ipCertificateFile));
            IEnumerable<IpCertificate>? DefaultBodyIpCertificates = JsonSerializer
                .Deserialize<IEnumerable<IpCertificate>>(jsonData);

            if (DefaultBodyIpCertificates == null) return "0 Body IpCertificate Added. ";

            foreach (var bodyIpCertificate in DefaultBodyIpCertificates)
            {
                _ipCertificateRepo.Add(bodyIpCertificate);
            }
            _ipCertificateRepo.Save();

            return DefaultBodyIpCertificates.Count() + " Body IpCertificate Added. ";
        }

        private string SeedBackMaterial()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, backMaterialFile));
            IEnumerable<BackMaterial>? defaultBackMaterials = JsonSerializer
                .Deserialize<IEnumerable<BackMaterial>>(jsonData);

            if (defaultBackMaterials == null) return "0 BackMaterial Added. ";

            foreach (var backMaterial in defaultBackMaterials)
            {
                _backMaterialRepository.Add(backMaterial);
            }
            _backMaterialRepository.Save();

            return defaultBackMaterials.Count() + " BackMaterial Added. ";
        }

        private string SeedFrameMaterial()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, frameMaterialFile));
            IEnumerable<FrameMaterial>? defaultFrameMaterials = JsonSerializer
                .Deserialize<IEnumerable<FrameMaterial>>(jsonData);

            if (defaultFrameMaterials == null) return "0 FrameMaterial Added. ";

            foreach (var frameMaterial in defaultFrameMaterials)
            {
                _frameMaterialRepository.Add(frameMaterial);
            }
            _frameMaterialRepository.Save();

            return defaultFrameMaterials.Count() + " FrameMaterial Added. ";
        }

        private string SeedOS()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, osFile));
            IEnumerable<OS>? defaultOSes = JsonSerializer
                .Deserialize<IEnumerable<OS>>(jsonData);

            if (defaultOSes == null) return "0 OS Added. ";

            foreach (var os in defaultOSes)
            {
                _osRepository.Add(os);
            }
            _osRepository.Save();

            return defaultOSes.Count() + " OS Added. ";
        }

        private string SeedChipset()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, chipsetFile));
            IEnumerable<Chipset>? defaultChipsets = JsonSerializer
                .Deserialize<IEnumerable<Chipset>>(jsonData);

            if (defaultChipsets == null) return "0 Chipset Added. ";

            foreach (var chipset in defaultChipsets)
            {
                _chipsetRepo.Add(chipset);
            }
            _chipsetRepo.Save();

            return defaultChipsets.Count() + " Chipset Added. ";
        }

        private string SeedOSVersion()
        {
            // Get all OSes
            var oses = _osRepository.GetAll();

            string jsonData = File.ReadAllText(Path.Combine(DataFolder, osVersionFile));
            IEnumerable<OSVersionSeedModel>? defaultOSSeedList = JsonSerializer
                .Deserialize<IEnumerable<OSVersionSeedModel>>(jsonData);

            if (defaultOSSeedList == null) return "0 OS Added. ";

            int osAddedCount = 0;
            foreach (var osVersionSeed in defaultOSSeedList)
            {
                // Find id from repository, using name from seed json
                var os = oses.Where(x => x.Name == osVersionSeed.OSName).FirstOrDefault();
                if (os != null)
                {
                    // Create model from seed model
                    var osVersion = new OSVersion
                    {
                        Name = osVersionSeed.Name,
                        OSId = os.Id
                    };
                    _osVersionRepo.Add(osVersion);
                    osAddedCount++;
                }
                
            }
            _osVersionRepo.Save();

            return osAddedCount + " OS Versions Added. ";
        }

        private string SeedCardSlot()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, cardSlotFile));
            IEnumerable<CardSlot>? defaultCardSlots = JsonSerializer
                .Deserialize<IEnumerable<CardSlot>>(jsonData);

            if (defaultCardSlots == null) return "0 CardSlot Added. ";

            foreach (var cardSlot in defaultCardSlots)
            {
                _cardSlotRepo.Add(cardSlot);
            }
            _cardSlotRepo.Save();

            return defaultCardSlots.Count() + " CardSlot Added. ";
        }

        private string SeedDisplayTechnology()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, displayTechnologyFile));
            IEnumerable<DisplayTechnology>? defaultDisplayTechnologies = JsonSerializer
                .Deserialize<IEnumerable<DisplayTechnology>>(jsonData);

            if (defaultDisplayTechnologies == null) return "0 DisplayTechnology Added. ";

            foreach (var displayTechnology in defaultDisplayTechnologies)
            {
                _displayTechnologyRepo.Add(displayTechnology);
            }
            _displayTechnologyRepo.Save();

            return defaultDisplayTechnologies.Count() + " DisplayTechnology Added. ";
        }

        private string SeedCamera()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, cameraFile));
            IEnumerable<CameraType>? defaultCameras = JsonSerializer
                .Deserialize<IEnumerable<CameraType>>(jsonData);

            if (defaultCameras == null) return "0 Camera Added. ";

            foreach (var camera in defaultCameras)
            {
                _cameraRepo.Add(camera);
            }
            _cameraRepo.Save();

            return defaultCameras.Count() + " Camera Added. ";
        }

        private string SeedFingerprint()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, fingerprintFile));
            IEnumerable<Fingerprint>? defaultFingerprints = JsonSerializer
                .Deserialize<IEnumerable<Fingerprint>>(jsonData);

            if (defaultFingerprints == null) return "0 Fingerprint Added. ";

            foreach (var fingerprint in defaultFingerprints)
            {
                _fingerprintRepo.Add(fingerprint);
            }
            _fingerprintRepo.Save();

            return defaultFingerprints.Count() + " Fingerprint Added. ";
        }

        private string SeedWifi()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, wifiFile));
            IEnumerable<Wifi>? defaultWifis = JsonSerializer
                .Deserialize<IEnumerable<Wifi>>(jsonData);

            if (defaultWifis == null) return "0 Wifi Added. ";

            foreach (var wifi in defaultWifis)
            {
                _wifiRepo.Add(wifi);
            }
            _wifiRepo.Save();

            return defaultWifis.Count() + " Wifi Added. ";
        }

        private string SeedBluetooth()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, bluetoothFile));
            IEnumerable<Bluetooth>? defaultBluetooths = JsonSerializer
                .Deserialize<IEnumerable<Bluetooth>>(jsonData);

            if (defaultBluetooths == null) return "0 Bluetooth Added. ";

            foreach (var bluetooth in defaultBluetooths)
            {
                _bluetoothRepo.Add(bluetooth);
            }
            _bluetoothRepo.Save();

            return defaultBluetooths.Count() + " Bluetooth Added. ";
        }

        private string SeedRemovableBattery()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, removableBatteryFile));
            IEnumerable<BatteryType>? defaultRemovableBatteries = JsonSerializer
                .Deserialize<IEnumerable<BatteryType>>(jsonData);

            if (defaultRemovableBatteries == null) return "0 RemovableBattery Added. ";

            foreach (var removableBattery in defaultRemovableBatteries)
            {
                _removableBatteryRepo.Add(removableBattery);
            }
            _removableBatteryRepo.Save();

            return defaultRemovableBatteries.Count() + " RemovableBattery Added. ";
        }

        private string SeedResolution()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, resolutionFile));
            IEnumerable<Resolution>? defaultResolutions = JsonSerializer
                .Deserialize<IEnumerable<Resolution>>(jsonData);

            if (defaultResolutions == null) return "0 Resolution Added. ";

            foreach (var resolution in defaultResolutions)
            {
                _resolutionRepo.Add(resolution);
            }
            _resolutionRepo.Save();

            return defaultResolutions.Count() + " Resolution Added. ";
        }

        private string SeedGPU()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, gpuFile));
            IEnumerable<GPU>? defaultGPUs = JsonSerializer
                .Deserialize<IEnumerable<GPU>>(jsonData);

            if (defaultGPUs == null) return "0 GPU Added. ";

            foreach (var gpu in defaultGPUs)
            {
                _gpuRepo.Add(gpu);
            }
            _gpuRepo.Save();

            return defaultGPUs.Count() + " GPU Added. ";
        }

        private string SeedLensType()
        {
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, lensTypeFile));
            IEnumerable<LensType>? defaultLensTypes = JsonSerializer
                .Deserialize<IEnumerable<LensType>>(jsonData);

            if (defaultLensTypes == null) return "0 LensType Added. ";

            foreach (var lensType in defaultLensTypes)
            {
                _lensTypeRepo.Add(lensType);
            }
            _lensTypeRepo.Save();

            return defaultLensTypes.Count() + " LensType Added. ";
        }

        public string DataFolder
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _dataFolderName);
            }
        }

        private string DeleteAllData()
        {
            // Get connection
            using var connection = SqlConnection;

            // DELETE from tables
            string sql = @"
DELETE FROM Category;
DELETE FROM Brand;
DELETE FROM Availability;
DELETE FROM NetworkBand;
DELETE FROM Network;
DELETE FROM SimSize;
DELETE FROM SimMultiple;
DELETE FROM FormFactor;
DELETE FROM IpCertificate;
DELETE FROM BackMaterial;
DELETE FROM FrameMaterial;
DELETE FROM OSVersion;
DELETE FROM OS;
DELETE FROM Chipset;
DELETE FROM CardSlot;
DELETE FROM DisplayTechnology;
DELETE FROM CameraType;
DELETE FROM Fingerprint;
DELETE FROM Wifi;
DELETE FROM Bluetooth;
DELETE FROM RemovableBattery;
DELETE FROM Resolution;
DELETE FROM GPU;
DELETE FROM LensType;
";
            int deletedRows = connection.Execute(sql);

            return deletedRows + " Records DELETED. ";
        }
    }
}
