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
                Name = c.Name
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
        public string OSName { get; set; } = string.Empty;
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
        public List<PhoneNetworksSeedModel>? Networks { get; set; }
        public class PhoneNetworksSeedModel
        {
            public string NetworkName { get; set; } = string.Empty;
            public List<string>? NetworkBands { get; set; }
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
