using products_api.Models;

namespace products_api.Dtos
{
    public static class CategoryExtensions
    {
        // Convert Category Model to Dto
        public static CategoryDto AsDto(this Category c)
        {
            return new CategoryDto
            { 
                Id = c.Id, 
                Name = c.Name, 
                Description = c.Description, 
                Position = c.Position
            };
        }
    }

    // Category Dto
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Category search result
    public class CategorySearchResult
    {
        public List<CategoryDto> Categories { get; set; } = new();
        public int TotalResults { get; set; } = 0;
    }

    // Category create Dto
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class CategoryUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
