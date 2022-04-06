using products_api.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("PhoneCamera")]
    public class PhoneCamera : BaseModel
    {
        public Guid CameraTypeId { get; set; }
        [ForeignKey("CameraTypeId")]
        public virtual CameraType CameraType { get; set; }
        public Guid PhoneId { get; set; }
        [ForeignKey("PhoneId")]
        public virtual Phone Phone { get; set; }
        public int Position { get; set; } = DefaultValues.Position;
        public int Resolution_MP { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal FNumber { get; set; }
        public int FocalLength_mm { get; set; }
        public string SensorSize { get; set; } = string.Empty;
        [Column(TypeName = "decimal(5, 1)")]
        public decimal PixelSize_um { get; set; }
        public bool OIS { get; set; }
        public Guid? LensTypeId { get; set; }
        [ForeignKey("LensTypeId")]
        public virtual LensType? LensType { get; set; }
    }
}
