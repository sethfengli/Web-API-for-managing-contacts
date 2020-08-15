using FluentValidation;

namespace code_test_contacts_api.Application.Emails.Commands
{
    public class CreateEmailCommandValidator : AbstractValidator<CreateEmailCommand>
    {
        public CreateEmailCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .MaximumLength(200)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
