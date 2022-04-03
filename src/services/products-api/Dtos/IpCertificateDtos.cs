using products_api.Models;

namespace products_api.Dtos
{
    public static class IpCertificateExtensions
    {
        // Convert IpCertificate Model to Dto
        public static IpCertificateDto AsDto(this IpCertificate c)
        {
            return new IpCertificateDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // IpCertificate Dto
    public class IpCertificateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // IpCertificate Dto
    public class IpCertificateCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class IpCertificateUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
