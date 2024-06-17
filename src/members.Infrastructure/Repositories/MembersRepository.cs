using members.Database.Infrastructure.Persistence;
using members.Application.Interfaces;
using members.Domain.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

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
    }
}
