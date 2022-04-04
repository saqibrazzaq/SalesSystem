using products_api.Models;

namespace products_api.Dtos
{
    public static class CameraTypeExtensions
    {
        // Convert CameraType Model to Dto
        public static CameraTypeDto AsDto(this CameraType c)
        {
            return new CameraTypeDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // CameraType Dto
    public class CameraTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // CameraType Dto
    public class CameraTypeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class CameraTypeUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
