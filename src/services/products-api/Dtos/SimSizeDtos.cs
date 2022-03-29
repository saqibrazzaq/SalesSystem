using products_api.Models;

namespace products_api.Dtos
{
    public static class SimSizeExtensions
    {
        // Convert SimSize Model to Dto
        public static SimSizeDto AsDto(this SimSize c)
        {
            return new SimSizeDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // SimSize Dto
    public class SimSizeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // SimSize Dto
    public class SimSizeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class SimSizeUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
