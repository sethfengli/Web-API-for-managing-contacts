using FluentValidation;

namespace code_test_contacts_api.Application.Phones.Commands
{
    public class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(v => v.PhoneNumber)
                .MaximumLength(20)
                .NotEmpty();
        }
    }
}
