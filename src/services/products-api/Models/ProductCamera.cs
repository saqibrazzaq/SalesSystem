using products_api.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("ProductCamera")]
    public class ProductCamera : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = DefaultValues.Position;
        public int Resolution_MP { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal FNumber { get; set; }
        public bool OIS { get; set; }

    }
}
