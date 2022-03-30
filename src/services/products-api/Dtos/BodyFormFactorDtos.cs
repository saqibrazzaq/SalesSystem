using products_api.Models;

namespace products_api.Dtos
{
    public static class BodyFormFactorExtensions
    {
        // Convert BodyFormFactor Model to Dto
        public static BodyFormFactorDto AsDto(this BodyFormFactor c)
        {
            return new BodyFormFactorDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // BodyFormFactor Dto
    public class BodyFormFactorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // BodyFormFactor Dto
    public class BodyFormFactorCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class BodyFormFactorUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
