using members.Database.Domain.Entities;
using members.Domain.Dtos;

namespace members.Application.Interfaces
{
    public interface IMembersRepository
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<IEnumerable<MemberDto>> GetCurrentMembersAsync();
        Task<MemberDto> SaveMemberAsync(Member member);
        Task<bool> PartyExistsInDbAsync(int? partyId);
    }
}
