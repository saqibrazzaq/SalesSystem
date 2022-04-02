using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("OS")]
    public class OS : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 1;

        // Related tables
        public virtual List<OSVersion> OSVersions { get; set; }
    }
}
