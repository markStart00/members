using AutoMapper;
using members.Application.Interfaces;
using members.Database.Domain.Entities;
using members.Domain.Dtos;
using members.Domain.Requests;

namespace members.Application.Services
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;

        public MembersService(IMembersRepository membersRepository, IMapper mapper)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            return await _membersRepository.GetAllMembersAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetCurrentMembersAsync()
        {
            return await _membersRepository.GetCurrentMembersAsync();
        }

        public async Task<MemberDto> SaveMemberAsync(AddMemberRequest request)
        {

            Member member = _mapper.Map<Member>(request);

            if (!await _membersRepository.PartyExistsInDbAsync(member.PartyId))
            {
                member.PartyId = null;
            }

            return await _membersRepository.SaveMemberAsync(member); 

        }

    }
}
