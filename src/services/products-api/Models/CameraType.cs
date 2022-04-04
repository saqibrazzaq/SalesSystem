using products_api.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("CameraType")]
    public class CameraType : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = DefaultValues.Position;
    }
}
