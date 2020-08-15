using FluentValidation;

namespace code_test_contacts_api.Application.Phones.Commands
{
    public class UpdatePhoneCommandValidator : AbstractValidator<UpdatePhoneCommand>
    {
        public UpdatePhoneCommandValidator()
        {
            RuleFor(v => v.PhoneNumber)
                .MaximumLength(20)
                .NotEmpty();
        }
    }
}
