using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteConactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteConactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Contact), request.Id);
            }

            _context.Contacts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
