using products_api.Models;

namespace products_api.Dtos
{
    public static class FingerprintExtensions
    {
        // Convert Fingerprint Model to Dto
        public static FingerprintDto AsDto(this Fingerprint c)
        {
            return new FingerprintDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // Fingerprint Dto
    public class FingerprintDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // Fingerprint Dto
    public class FingerprintCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class FingerprintUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
