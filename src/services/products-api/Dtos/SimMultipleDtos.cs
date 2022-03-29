using products_api.Models;

namespace products_api.Dtos
{
    public static class SimMultipleExtensions
    {
        // Convert SimMultiple Model to Dto
        public static SimMultipleDto AsDto(this SimMultiple c)
        {
            return new SimMultipleDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // SimMultiple Dto
    public class SimMultipleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // SimMultiple Dto
    public class SimMultipleCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class SimMultipleUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
