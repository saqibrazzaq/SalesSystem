using products_api.Models;

namespace products_api.Dtos
{
    public static class RemovableBatteryExtensions
    {
        // Convert RemovableBattery Model to Dto
        public static RemovableBatteryDto AsDto(this RemovableBattery c)
        {
            return new RemovableBatteryDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // RemovableBattery Dto
    public class RemovableBatteryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // RemovableBattery Dto
    public class RemovableBatteryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class RemovableBatteryUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
