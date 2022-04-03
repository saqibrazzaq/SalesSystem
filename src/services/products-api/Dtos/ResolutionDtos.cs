using products_api.Models;

namespace products_api.Dtos
{
    public static class ResolutionExtensions
    {
        // Convert Resolution Model to Dto
        public static ResolutionDto AsDto(this Resolution c)
        {
            return new ResolutionDto
            { 
                Id = c.Id, 
                Name = $"{c.Name} ({c.PixelsRow}x{c.PixelsCol})",
                Position = c.Position
            };
        }
    }

    // Resolution Dto
    public class ResolutionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Resolution Dto
    public class ResolutionCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
        public int PixelsRow { get; set; }
        public int PixelsCol { get; set; }
    }

    public class ResolutionUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
        public int PixelsRow { get; set; }
        public int PixelsCol { get; set; }
    }
}
