using members.Database.Infrastructure.Persistence;
using members.Application.Interfaces;
using members.Domain.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using members.Domain.Requests;
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
            //.Include(o => o.OtherTable)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<MemberDto> SaveMemberAsync(AddMemberRequest request)
        {
            // check for uniqueness but need more fields than just lastname

            //if (await _membersDbContext.Members.AnyAsync(m => m.LastName == request.LastName))
            //{
            //    throw new MemberExistsException();
            //}

            // the db generate id is updated in the Member model by ef when saveChangesAsync()
            // there is no need to get the newly added memeber from the db

            Member member = _mapper.Map<Member>(request);

            _membersDbContext.Members.Add(member);

            await _membersDbContext.SaveChangesAsync();

            MemberDto memberDto = _mapper.Map<MemberDto>(member);

            return memberDto;

        }

    }
}
