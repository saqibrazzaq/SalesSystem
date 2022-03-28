using products_api.Models;

namespace products_api.Dtos
{
    public static class BrandExtensions
    {
        // Convert Brand Model to Dto
        public static BrandDto AsDto(this Brand c)
        {
            return new BrandDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Brand Dto
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Brand search result
    public class BrandSearchResult
    {
        public List<BrandDto> Brands { get; set; } = new();
        public int TotalResults { get; set; } = 0;
    }

    // Category Brand Dto
    public class BrandCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class BrandUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
