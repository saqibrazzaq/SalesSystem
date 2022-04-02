using products_api.Models;

namespace products_api.Dtos
{
    public static class ChipsetExtensions
    {
        // Convert Chipset Model to Dto
        public static ChipsetDto AsDto(this Chipset c)
        {
            return new ChipsetDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Chipset Dto
    public class ChipsetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Chipset Dto
    public class ChipsetCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class ChipsetUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
