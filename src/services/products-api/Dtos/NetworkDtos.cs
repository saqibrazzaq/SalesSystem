using products_api.Models;

namespace products_api.Dtos
{
    public static class NetworkExtensions
    {
        // Convert Network Model to Dto
        public static NetworkDto AsDto(this Network c)
        {
            return new NetworkDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Network Dto
    public class NetworkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Network search result
    public class NetworkSearchResult
    {
        public List<NetworkDto> Networks { get; set; } = new();
        public int TotalResults { get; set; } = 0;
    }

    // Category Network Dto
    public class NetworkCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class NetworkUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
