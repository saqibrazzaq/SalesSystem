using products_api.Models;

namespace products_api.Dtos
{
    public static class PhoneExtensions
    {
        // Convert Product Model to Dto
        public static PhoneDto AsDto(this Phone c)
        {
            return new PhoneDto
            { 
                Id = c.Id, 
                Name = c.Name,
                AnnouncedDate = c.AnnouncedDate,
                BatteryCapacity_mAh = c.BatteryCapacity_mAh,
                CpuCores = c.CpuCores,
                CpuDetails = c.CpuDetails,
                DisplaySize_in = c.DisplaySize_in,
                Height_mm = c.Height_mm,
                OSId = c.OSId,
                OSVersionId = c.OSVersionId,
                RAM_bytes = c.RAM_bytes,
                ReleaseDate = c.ReleaseDate,
                Storage_bytes = c.Storage_bytes,
                Thickness_mm = c.Thickness_mm,
                Weight_grams = c.Weight_grams,
                Width_mm = c.Width_mm
            };
        }
    }

    // Phone Dto
    public class PhoneDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime AnnouncedDate { get; set; }
        public int Weight_grams { get; set; }
        public decimal Height_mm { get; set; }
        public decimal Width_mm { get; set; }
        public decimal Thickness_mm { get; set; }
        public decimal DisplaySize_in { get; set; }
        public Guid? OSId { get; set; }
        public string OSName { get; set; } = string.Empty;
        public Guid? OSVersionId { get; set; }
        public string OSVersionName { get; set; } = string.Empty;
        public long RAM_bytes { get; set; }
        public long Storage_bytes { get; set; }
        public string SDCardSlotName { get; set; } = string.Empty;
        public int BatteryCapacity_mAh { get; set; }
        public string ChipsetName { get; set; } = string.Empty;
        public int CpuCores { get; set; }
        public string CpuDetails { get; set; } = string.Empty;
        public string GpuName { get; set; } = string.Empty;

    }

    // Phone Dto
    public class PhoneCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime AnnouncedDate { get; set; }
        public int Weight_grams { get; set; }
        public decimal Height_mm { get; set; }
        public decimal Width_mm { get; set; }
        public decimal Thickness_mm { get; set; }
        public decimal DisplaySize_in { get; set; }
        public Guid? OSId { get; set; }
        public Guid? OSVersionId { get; set; }
        public long RAM_bytes { get; set; }
        public long Storage_bytes { get; set; }
        public Guid? SDCardSlotId { get; set; }
        public int BatteryCapacity_mAh { get; set; }
        public Guid? ChipsetId { get; set; }
        public Guid? GPUId { get; set; }
        public int CpuCores { get; set; }
        public string CpuDetails { get; set; } = string.Empty;
    }

    // Phone Seed Model
    public class PhoneSeedModel
    {
        public string Name { get; set; } = string.Empty;
        public int Weight_grams { get; set; }
        public decimal Height_mm { get; set; }
        public decimal Width_mm { get; set; }
        public decimal Thickness_mm { get; set; }
        public decimal DisplaySize_in { get; set; }
        public string OSName { get; set; } = string.Empty;
        public string OSVersionName { get; set; } = string.Empty;
        public long RAM_bytes { get; set; }
        public long Storage_bytes { get; set; }
        public string SDCardSlotName { get; set; } = string.Empty;
        public int BatteryCapacity_mAh { get; set; }
        public string ChipsetName { get; set; } = string.Empty;
        public string GPUName { get; set; } = string.Empty;
        public int CpuCores { get; set; }
        public string CpuDetails { get; set; } = string.Empty;
        public List<PhoneNetworksSeedModel>? PhoneNetworks { get; set; }
        public List<PhoneCameraSeedModel>? PhoneCameras { get; set; }
        public class PhoneNetworksSeedModel
        {
            public string NetworkName { get; set; } = string.Empty;
            public List<string>? NetworkBands { get; set; }
        }
        public class PhoneCameraSeedModel
        {
            public string CameraTypeName { get; set; } = string.Empty;
            public int Position { get; set; }
            public int Resolution_MP { get; set; }
            public decimal FNumber { get; set; }
            public int FocalLength_mm { get; set; }
            public string SensorSize { get; set; } = string.Empty;
            public decimal PixelSize_um { get; set; }
            public bool OIS { get; set; }
            public string LensTypeName { get; set; } = string.Empty;
        }
    }

    public class PhoneUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime AnnouncedDate { get; set; }
        public int Weight_grams { get; set; }
        public decimal Height_mm { get; set; }
        public decimal Width_mm { get; set; }
        public decimal Thickness_mm { get; set; }
        public decimal DisplaySize_in { get; set; }
        public Guid? OSId { get; set; }
        public Guid? OSVersionId { get; set; }
        public long RAM_bytes { get; set; }
        public long Storage_bytes { get; set; }
        public Guid? SDCardSlotId { get; set; }
        public int BatteryCapacity_mAh { get; set; }
        public Guid? ChipsetId { get; set; }
        public Guid? GPUId { get; set; }
        public int CpuCores { get; set; }
        public string CpuDetails { get; set; } = string.Empty;
    }
}
