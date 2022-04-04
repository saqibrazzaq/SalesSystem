using products_api.Models;

namespace products_api.Dtos
{
    public static class LensTypeExtensions
    {
        // Convert LensType Model to Dto
        public static LensTypeDto AsDto(this LensType c)
        {
            return new LensTypeDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // LensType Dto
    public class LensTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // LensType Dto
    public class LensTypeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class LensTypeUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
