using products_api.Models;

namespace products_api.Dtos
{
    public static class CameraExtensions
    {
        // Convert Camera Model to Dto
        public static CameraDto AsDto(this Camera c)
        {
            return new CameraDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Camera Dto
    public class CameraDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Camera Dto
    public class CameraCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class CameraUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
