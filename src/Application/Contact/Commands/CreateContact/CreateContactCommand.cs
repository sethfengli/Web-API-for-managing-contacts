using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using code_test_contacts_api.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Commands
{
    public partial class CreateContactCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Note { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Contact();

            entity.Title = request.Title;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Note = request.Note;
            entity.Sex = request.Sex;
            entity.DateOfBirth = request.DateOfBirth;
                   
            _context.Contacts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
