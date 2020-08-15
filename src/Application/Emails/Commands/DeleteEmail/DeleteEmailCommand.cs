using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Emails.Commands
{
    public class DeleteEmailCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteEmailCommandHandler : IRequestHandler<DeleteEmailCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Emails.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            _context.Emails.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
