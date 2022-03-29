using products_api.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace products_api.Models
{
    [Table("NetworkBand")]
    public class NetworkBand : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = DefaultValues.Position;
        
        public Guid? NetworkId { get; set; }
        [ForeignKey("NetworkId")]
        [JsonIgnore]
        public virtual Network? Network { get; set; }
    }
}
