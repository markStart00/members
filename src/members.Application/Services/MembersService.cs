using members.Application.Extensions;
using members.Application.Interfaces;
using members.Domain.Dtos;
using members.Domain.Requests;

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

        public async Task<MemberDto> SaveMemberAsync(AddMemberRequest request)
        {

            request.LastName = request.LastName.NormalizeToLowerCase();

            return await _membersRepository.SaveMemberAsync(request); 
        }

    }
}
