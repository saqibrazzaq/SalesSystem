using products_api.Models;

namespace products_api.Dtos
{
    public static class CardSlotExtensions
    {
        // Convert CardSlot Model to Dto
        public static CardSlotDto AsDto(this CardSlot c)
        {
            return new CardSlotDto
            { 
                Id = c.Id, 
                Name = c.Name,
                Position = c.Position
            };
        }
    }

    // CardSlot Dto
    public class CardSlotDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    // CardSlot Dto
    public class CardSlotCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }

    public class CardSlotUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
