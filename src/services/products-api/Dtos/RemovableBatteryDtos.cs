using products_api.Models;

namespace products_api.Dtos
{
    public static class BatteryTypeExtensions
    {
        // Convert BatteryType Model to Dto
        public static BatteryTypeDto AsDto(this BatteryType c)
        {
            return new BatteryTypeDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // BatteryType Dto
    public class BatteryTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // BatteryType Dto
    public class BatteryTypeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class BatteryTypeUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
