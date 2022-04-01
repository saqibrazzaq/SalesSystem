using products_api.Models;

namespace products_api.Dtos
{
    public static class BackMaterialExtensions
    {
        // Convert BackMaterial Model to Dto
        public static BackMaterialDto AsDto(this BackMaterial c)
        {
            return new BackMaterialDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // BackMaterial Dto
    public class BackMaterialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // BackMaterial Dto
    public class BackMaterialCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class BackMaterialUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
