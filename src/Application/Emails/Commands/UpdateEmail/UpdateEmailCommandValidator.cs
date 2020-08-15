using FluentValidation;

namespace code_test_contacts_api.Application.Emails.Commands
{
    public class UpdateEmailCommandValidator : AbstractValidator<UpdateEmailCommand>
    {
        public UpdateEmailCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .MaximumLength(200)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
