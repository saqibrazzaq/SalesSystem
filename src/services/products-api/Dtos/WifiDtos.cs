using products_api.Models;

namespace products_api.Dtos
{
    public static class WifiExtensions
    {
        // Convert Wifi Model to Dto
        public static WifiDto AsDto(this Wifi c)
        {
            return new WifiDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Wifi Dto
    public class WifiDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Wifi Dto
    public class WifiCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class WifiUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
