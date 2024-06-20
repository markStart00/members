namespace members.Domain.Dtos
{
    public class PartyDto
    {
        public int PartyId { get; set; }
        public required string Name { get; set; }
        public string? Colour { get; set; }
    }
}
