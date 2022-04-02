using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("OSVersion")]
    public class OSVersion : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 1;
        [Required]
        public Guid OSId { get; set; }
        [ForeignKey("OSId")]
        public virtual OS OS { get; set; }
    }
}
