using members.Application.Interfaces;
using members.Application.Services;
using members.Domain.Dtos;
using Moq;
using Xunit;

namespace members.Application.UnitTests
{
    public class GetAllMembersTests
    {
	    /*
        private readonly Mock<IMembersRepository> _membersRepository;

        public GetAllMembersTests()
        {
            _membersRepository = new Mock<IMembersRepository>();
        }

        [Fact]
        public async Task GetAllMembers_ReturnsListOfMembersAsync()
        {
            // Arrange
            _membersRepository.Setup(x => x.GetAllMembersAsync()).ReturnsAsync(new List<MemberDto>());
            var membersService = new MembersService(_membersRepository.Object);

            // Act 
            var allMembers = await membersService.GetAllMembersAsync();

            // Assert
            Assert.NotNull(allMembers);
            Assert.IsType<List<MemberDto>>(allMembers);

        }
	*/

    }
}
