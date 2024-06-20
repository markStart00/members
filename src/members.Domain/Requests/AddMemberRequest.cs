namespace members.Domain.Requests
{
    public class AddMemberRequest
    {
        public int HouseOfLordsId { get; set; }
        public required string NameFullTitle { get; set; }
        public string? Gender { get; set; }

        public int PartyId { get; set; }

        public bool? MembershipStatusIsActive { get; set; }

        public required string MembershipStartDate { get; set; }
        public string? MembershipEndDate { get; set; }

        public string? MembershipEndReason { get; set; }

        // life-peer / a location 
        public string? MemberFrom { get; set; }

        public string? ImageUrl { get; set; }

    }
}
