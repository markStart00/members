using FluentValidation;
using FluentValidation.Results;
using members.Application.Interfaces;
using members.Domain.Dtos;
using members.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

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

            app.MapGet("/current-members", async (IMembersService membersService) =>
            {
                return Results.Ok(await membersService.GetCurrentMembersAsync());
            });

            app.MapPut("add-member", async (
                [FromBody] AddMemberRequest request,
                IValidator<AddMemberRequest> validator,
                IMembersService membersService) => 
            {
                ValidationResult validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());

                MemberDto member = await membersService.SaveMemberAsync(request);

                return Results.Ok(member);

            });

        }
    }
}
