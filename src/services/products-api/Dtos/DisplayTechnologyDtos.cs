using products_api.Models;

namespace products_api.Dtos
{
    public static class DisplayTechnologyExtensions
    {
        // Convert DisplayTechnology Model to Dto
        public static DisplayTechnologyDto AsDto(this DisplayTechnology c)
        {
            return new DisplayTechnologyDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // DisplayTechnology Dto
    public class DisplayTechnologyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // DisplayTechnology Dto
    public class DisplayTechnologyCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class DisplayTechnologyUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
