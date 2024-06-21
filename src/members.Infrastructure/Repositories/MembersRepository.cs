using members.Database.Infrastructure.Persistence;
using members.Application.Interfaces;
using members.Domain.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using members.Application.Exceptions;
using members.Database.Domain.Entities;

namespace members.Infrastructure.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly MembersDbContext _membersDbContext;
        private readonly IMapper _mapper;

        public MembersRepository(MembersDbContext membersDbContext, IMapper mapper)
        {
            _membersDbContext = membersDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            return await _membersDbContext.Members
                .Include(m => m.Party)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetCurrentMembersAsync()
        {
            return await _membersDbContext.Members
                .Where(m => m.MembershipEndDate == null)
                .Include(m => m.Party)
                .OrderBy(m => m.Party != null ? m.Party.Name : null)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> PartyExistsInDbAsync(int? partyId)
        {
            if (partyId == null) return false;

            return await _membersDbContext.Parties.AnyAsync(m => m.PartyId == partyId);
        }

        public async Task<MemberDto> SaveMemberAsync(Member member)
        {

            if (await _membersDbContext.Members.AnyAsync(m => m.HouseOfLordsId == member.HouseOfLordsId))
            {
                throw new MemberExistsException();
            }

            // the db generates id and ef updates the Member model id when saveChangesAsync()
            // there is no need to get the newly added memeber from the db

            _membersDbContext.Members.Add(member);

            await _membersDbContext.SaveChangesAsync();

            MemberDto memberDto = _mapper.Map<MemberDto>(member);

            return memberDto;

        }

    }
}
