using products_api.Models;

namespace products_api.Dtos
{
    public static class OSVersionExtensions
    {
        // Convert OSVersion Model to Dto
        public static OSVersionDto AsDto(this OSVersion c)
        {
            return new OSVersionDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position,
                OSId = c.OSId,
                OsName = (c.OS != null) ? c.OS.Name : ""
            };
        }
    }

    // OSVersion Dto
    public class OSVersionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
        public Guid OSId { get; set; }
        public string OsName { get; set; }
    }

    // Category OSVersion Dto
    public class OSVersionCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
        public Guid OsId { get; set; }
    }

    public class OSVersionUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class OSVersionSeedModel
    {
        public string Name { get; set; } = string.Empty;
        public string OSName { get; set; } = string.Empty;
    }
}
