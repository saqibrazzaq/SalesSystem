using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("SimSize")]
    public class SimSize : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 1;
    }
}
