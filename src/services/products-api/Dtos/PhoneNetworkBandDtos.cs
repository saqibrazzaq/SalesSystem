using products_api.Models;

namespace products_api.Dtos
{
    public static class PhoneNetworkBandExtensions
    {
        // Convert PhoneNetworkBand Model to Dto
        public static PhoneNetworkBandDto AsDto(this PhoneNetworkBand c)
        {
            return new PhoneNetworkBandDto
            { 
                Id = c.Id, 
                NetworkBandId = c.NetworkBandId,
                PhoneId = c.PhoneId
            };
        }
    }

    

    // PhoneNetworkBand Dto
    public class PhoneNetworkBandDto
    {
        public Guid Id { get; set; }
        public Guid PhoneId { get; set; }
        public Guid NetworkBandId { get; set; }
    }

    // PhoneNetworkBand Dto
    public class PhoneNetworkBandCreateDto
    {
        public Guid PhoneId { get; set; }
        public Guid NetworkBandId { get; set; }
    }
}
