using FluentValidation;
using members.Domain.Requests;

namespace members.Application.Validators
{
    public class AddMemberRequestValidator : AbstractValidator<AddMemberRequest>
    {
        public AddMemberRequestValidator() 
        {
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        }

    }
}
