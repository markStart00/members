using members.Domain.Dtos;
using members.Domain.Requests;

namespace members.Application.Interfaces
{
    public interface IMembersRepository
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<MemberDto> SaveMemberAsync(AddMemberRequest request);
    }
}
