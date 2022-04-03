using products_api.Models;

namespace products_api.Dtos
{
    public static class GPUExtensions
    {
        // Convert GPU Model to Dto
        public static GPUDto AsDto(this GPU c)
        {
            return new GPUDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // GPU Dto
    public class GPUDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // GPU Dto
    public class GPUCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class GPUUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
