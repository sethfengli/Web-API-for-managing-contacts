using code_test_contacts_api.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Commands
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .MaximumLength(20).WithMessage("Title must not exceed 20 characters.");

            RuleFor(v => v.FirstName)
                .NotEmpty().When(v => string.IsNullOrEmpty(v.LastName)).WithMessage("*Either First Name or Last Name is required");

            RuleFor(v => v.FirstName)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(v => v.LastName)
                .NotEmpty().When(m => string.IsNullOrEmpty(m.FirstName)).WithMessage("*Either First Name or Last Name is required");

            RuleFor(v => v.LastName)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }

    }
}
