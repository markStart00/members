using members.Application.Interfaces;
using members.Domain.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace members.Apitests;

public class GetAllMembersApiTests 
{
	/*
    private readonly Mock<IMembersService> _membersService;

    public GetAllMembersApiTests()
    {
        _membersService = new Mock<IMembersService>();
    }

    [Fact]
    public async void GetAllMembers_ReturnsResultsOkWithListOfAllMembers()
    {
        // Arrange 
        await using var application = new TestApplicationFactory(Xunit =>
        {
            Xunit.AddSingleton(_membersService.Object);
        });
        var client = application.CreateClient();

        _membersService.Setup(x => x.GetAllMembersAsync()).ReturnsAsync(new List<MemberDto>());

        // Act
        var response = await client.GetAsync("/all-members");
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<MemberDto>>(responseContent);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseContent);
        Assert.IsType<List<MemberDto>>(result);
        
    }

    [Fact]
    public async void GetAllMembers_WhenException_ReturnsInternalServerErrorStatusCode()
    {
        // Arrange 
        await using var application = new TestApplicationFactory(x =>
        {
            x.AddSingleton(_membersService.Object);
        });
        var client = application.CreateClient();

        _membersService.Setup(x => x.GetAllMembersAsync()).Throws<Exception>();

        // Act
        var response = await client.GetAsync("/all-members");

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

    } 
*/

}
