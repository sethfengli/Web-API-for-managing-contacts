using code_test_contacts_api.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Commands
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .MaximumLength(20).WithMessage("Title must not exceed 20 characters.");

            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }

       
    }
}
