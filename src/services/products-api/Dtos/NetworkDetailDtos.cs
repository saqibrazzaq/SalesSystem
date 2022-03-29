using products_api.Models;

namespace products_api.Dtos
{
    public static class NetworkBandExtensions
    {
        // Convert NetworkBand Model to Dto
        public static NetworkBandDto AsDto(this NetworkBand c)
        {
            return new NetworkBandDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // NetworkBand Dto
    public class NetworkBandDto
    {
        public Guid Id { get; set; }
        public Guid NetworkId { get; set; }
        public string NetworkName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // NetworkBand Dto
    public class NetworkBandCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class NetworkBandUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
