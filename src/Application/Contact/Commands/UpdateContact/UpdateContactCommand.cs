using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using code_test_contacts_api.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Commands
{
    public class UpdateContactCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Note { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Contact), request.Id);
            }

            entity.Title = request.Title;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Note = request.Note;
            entity.Sex = request.Sex;
            entity.DateOfBirth = request.DateOfBirth;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
