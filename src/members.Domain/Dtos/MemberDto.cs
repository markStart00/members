namespace members.Domain.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public int HouseOfLordsId { get; set; }
        public required string NameFullTitle { get; set; }
        public string? Gender { get; set; }
        public int? PartyId { get; set; }
        public bool? MembershipStatusIsActive { get; set; }
        public required DateTime MembershipStartDate { get; set; }
        public DateTime? MembershipEndDate { get; set; }
        public string? MembershipEndReason { get; set; }
        public string? MemberFrom { get; set; }
        public string? ImageUrl { get; set; }

        public PartyDto? Party { get; set; }

    }
}
