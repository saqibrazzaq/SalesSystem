using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("SimMultiple")]
    public class SimMultiple : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 1;
    }
}
