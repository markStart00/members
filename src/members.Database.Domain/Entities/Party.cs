namespace members.Database.Domain.Entities
{
    public class Party
    {
        public int PartyId { get; set; }
        public required string Name { get; set; }
        public string? Colour { get; set; }
    }
}
