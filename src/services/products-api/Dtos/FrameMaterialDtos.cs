using products_api.Models;

namespace products_api.Dtos
{
    public static class FrameMaterialExtensions
    {
        // Convert FrameMaterial Model to Dto
        public static FrameMaterialDto AsDto(this FrameMaterial c)
        {
            return new FrameMaterialDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // FrameMaterial Dto
    public class FrameMaterialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // FrameMaterial Dto
    public class FrameMaterialCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class FrameMaterialUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
