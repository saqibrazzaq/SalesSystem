using products_api.Models;

namespace products_api.Dtos
{
    public static class ProductExtensions
    {
        // Convert Product Model to Dto
        public static ProductDto AsDto(this Product c)
        {
            return new ProductDto
            { 
                Id = c.Id, 
                Name = c.Name
            };
        }
    }

    // Product Dto
    public class ProductDto
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
        public int RAM_bytes { get; set; }
        public int Storage_bytes { get; set; }
        public string SDCardSlotName { get; set; } = string.Empty;
        public int BatteryCapacity_mAh { get; set; }
        public string ChipsetName { get; set; } = string.Empty;
        public int CpuCores { get; set; }
        public string CpuDetails { get; set; } = string.Empty;

    }

    // Product Dto
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class ProductUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
