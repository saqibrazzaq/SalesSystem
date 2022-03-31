using products_api.Models;

namespace products_api.Dtos
{
    public static class BodyIpCertificateExtensions
    {
        // Convert BodyIpCertificate Model to Dto
        public static BodyIpCertificateDto AsDto(this BodyIpCertificate c)
        {
            return new BodyIpCertificateDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // BodyIpCertificate Dto
    public class BodyIpCertificateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // BodyIpCertificate Dto
    public class BodyIpCertificateCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class BodyIpCertificateUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
