using members.Domain.Dtos;

namespace members.Application.Interfaces
{
    public interface IMembersService
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
    }
}
