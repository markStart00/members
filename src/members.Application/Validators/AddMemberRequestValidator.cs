using FluentValidation;
using members.Domain.Requests;

namespace members.Application.Validators
{
    public class AddMemberRequestValidator : AbstractValidator<AddMemberRequest>
    {
        public AddMemberRequestValidator()
        {
            RuleFor(x => x.HouseOfLordsId).NotEmpty().WithMessage("HouseOfLordsId cannot be empty");
            RuleFor(x => x.NameFullTitle).NotEmpty().MaximumLength(100).WithMessage("NameFullTitle cannot be empty or > 100");
            RuleFor(x => x.MembershipStartDate).NotEmpty().WithMessage("MembershipStartDate cannot be empty");
        }

    }
}
