using members.Application.Interfaces;
using members.Domain.Dtos;

namespace members.Application.Services
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;

        public MembersService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            return await _membersRepository.GetAllMembersAsync();
        }

    }
}
