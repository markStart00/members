using members.Application.Interfaces;

namespace members.Api.Extensions
{
    public static class MemberEndpointExtensions
    {
        public static void MapMemberEndpoints(this WebApplication app)
        {

            app.MapGet("/all-members", async (IMembersService membersService) =>
            {
                return Results.Ok( await membersService.GetAllMembersAsync());
            });


        }
    }
}
