using products_api.Models;

namespace products_api.Dtos
{
    public static class BluetoothExtensions
    {
        // Convert Bluetooth Model to Dto
        public static BluetoothDto AsDto(this Bluetooth c)
        {
            return new BluetoothDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Bluetooth Dto
    public class BluetoothDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Bluetooth Dto
    public class BluetoothCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class BluetoothUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
