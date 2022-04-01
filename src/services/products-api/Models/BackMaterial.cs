using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("BackMaterial")]
    public class BackMaterial : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 1;
    }
}
