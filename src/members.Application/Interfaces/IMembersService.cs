using members.Domain.Dtos;
using members.Domain.Requests;

namespace members.Application.Interfaces
{
    public interface IMembersService
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<IEnumerable<MemberDto>> GetCurrentMembersAsync();
        Task<MemberDto> SaveMemberAsync(AddMemberRequest request);
    }
}
