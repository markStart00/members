using AutoMapper;
using members.Application.Mappings;
using members.Database.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace members.Database.Infrastructure.UnitTests
{
    public class MembersDbContextUnitTests
    {
        private readonly DbContextOptions<MembersDbContext> _options;
        private readonly IMapper _mapper;

        public MembersDbContextUnitTests()
        {
            _options = new DbContextOptionsBuilder<MembersDbContext>()
                .UseInMemoryDatabase(databaseName: "TestMembersDatabase")
                .Options;

            var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = new Mapper(mappingConfig);

        }

        [Fact]
        public void MembersDbContextGetTypeTest()
        {
            var dbContext = new MembersDbContext(_options);
            Assert.True(dbContext.GetType().Name == nameof(MembersDbContext));
        }

        // can write additional in-memory db crud tests

    }
}
