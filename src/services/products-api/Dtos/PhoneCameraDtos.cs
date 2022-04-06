using products_api.Models;

namespace products_api.Dtos
{
    public static class ProductCameraExtensions
    {
        // Convert ProductCamera Model to Dto
        public static PhoneCameraDto AsDto(this PhoneCamera c)
        {
            return new PhoneCameraDto
            { 
                Id = c.Id, 
                Position = c.Position,
                CameraTypeName = c.CameraType.Name,
                FNumber = c.FNumber,
                FocalLength_mm = c.FocalLength_mm,
                LensTypeName = c.LensType == null ? string.Empty : c.LensType.Name,
                OIS = c.OIS,
                PixelSize_um = c.PixelSize_um,
                Resolution_MP = c.Resolution_MP,
                SensorSize = c.SensorSize
            };
        }
    }

    // ProductCamera Dto
    public class PhoneCameraDto
    {
        public Guid Id { get; set; }
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

    // ProductCamera Dto
    public class PhoneCameraCreateDto
    {
        public Guid CameraTypeId { get; set; }
        public Guid PhoneId { get; set; }
        public int Position { get; set; }
        public int Resolution_MP { get; set; }
        public decimal FNumber { get; set; }
        public int FocalLength_mm { get; set; }
        public string SensorSize { get; set; } = string.Empty;
        public decimal PixelSize_um { get; set; }
        public bool OIS { get; set; }
        public Guid LensTypeId { get; set; }
    }

    public class PhoneCameraUpdateDto
    {
        public int Position { get; set; }
        public int Resolution_MP { get; set; }
        public decimal FNumber { get; set; }
        public int FocalLength_mm { get; set; }
        public string SensorSize { get; set; } = string.Empty;
        public decimal PixelSize_um { get; set; }
        public bool OIS { get; set; }
        public Guid LensTypeId { get; set; }
    }
}
