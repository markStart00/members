using members.Database.Domain.Entities;
using members.Domain.Dtos;

namespace members.Application.Interfaces
{
    public interface IMembersRepository
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
    }
}
