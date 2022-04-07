using products_api.Dtos;
using products_api.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_api.Models
{
    [Table("PhoneNetworkBand")]
    public class PhoneNetworkBand : BaseModel
    {
        public Guid PhoneId { get; set; }
        [ForeignKey("PhoneId")]
        public virtual Phone Phone { get; set; }
        public Guid NetworkBandId { get; set; }
        [ForeignKey("NetworkBandId")]
        public virtual NetworkBand NetworkBand { get; set; }
    }

    public static class PhoneNetworkBandExtensions1
    {
        // Convert Dto to PhoneNetworkBand Model 
        public static PhoneNetworkBand AsModel(this PhoneNetworkBandDto c)
        {
            return new PhoneNetworkBand
            {
                Id = c.Id,
                NetworkBandId = c.NetworkBandId,
                PhoneId = c.PhoneId
            };
        }
    }
}
