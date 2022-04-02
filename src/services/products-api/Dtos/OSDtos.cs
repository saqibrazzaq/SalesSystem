using products_api.Models;

namespace products_api.Dtos
{
    public static class OSExtensions
    {
        // Convert OS Model to Dto
        public static OSDto AsDto(this OS c)
        {
            return new OSDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // OS Dto
    public class OSDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Category OS Dto
    public class OSCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class OSUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
