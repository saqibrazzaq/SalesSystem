using products_api.Models;

namespace products_api.Dtos
{
    public static class BodyFormFactorExtensions
    {
        // Convert FormFactor Model to Dto
        public static FormFactorDto AsDto(this FormFactor c)
        {
            return new FormFactorDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // FormFactor Dto
    public class FormFactorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // FormFactor Dto
    public class FormFactorCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class FormFactorUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
