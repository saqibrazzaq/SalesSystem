using products_api.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("Phone")]
    public class Phone : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime AnnouncedDate { get; set; }
        public int Weight_grams { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal Height_mm { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal Width_mm { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal Thickness_mm { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal DisplaySize_in { get; set; }
        public Guid? OSId { get; set; }
        [ForeignKey("OSId")]
        public virtual OS? OS { get; set; }
        public Guid? OSVersionId { get; set; }
        [ForeignKey("OSVersionId")]
        public virtual OSVersion? OSVersion { get; set; }
        public long RAM_bytes { get; set; }
        public long Storage_bytes { get; set; }
        public Guid? SDCardSlotId { get; set; }
        [ForeignKey("SDCardSlotId")]
        public virtual CardSlot? CardSlot { get; set; }
        public int BatteryCapacity_mAh { get; set; }
        public Guid? ChipsetId { get; set; }
        [ForeignKey("ChipsetId")]
        public virtual Chipset? Chipset { get; set; }
        public Guid? GPUId { get; set; }
        [ForeignKey("GPUId")]
        public virtual GPU? GPU { get; set; }
        public int CpuCores { get; set; }
        public string CpuDetails { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = DefaultValues.PhoneImage;

        // Related tables
        public virtual IEnumerable<PhoneCamera> PhoneCameras { get; set; }
    }
}
