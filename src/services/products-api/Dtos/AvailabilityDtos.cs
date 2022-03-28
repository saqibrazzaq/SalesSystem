using products_api.Models;

namespace products_api.Dtos
{
    public static class AvailabilityExtensions
    {
        // Convert Availability Model to Dto
        public static AvailabilityDto AsDto(this Availability c)
        {
            return new AvailabilityDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Availability Dto
    public class AvailabilityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Availability search result
    public class AvailabilitySearchResult
    {
        public List<AvailabilityDto> Availabilities { get; set; } = new();
        public int TotalResults { get; set; } = 0;
    }

    // Availability Dto
    public class AvailabilityCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class AvailabilityUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
