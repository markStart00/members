namespace members.Api.Extensions
{
    public static class MemberEndpointExtensions
    {
        public static void MapMemberEndpoints(this WebApplication app)
        {

            app.MapGet("/all-members", () =>
            {
                //MembersDto allMembers = membersService.GetMembers();
                return Results.Ok();
            });


        }
    }
}
