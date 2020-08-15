using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Phones.Commands
{
    public class DeletePhoneCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePhoneCommandHandler : IRequestHandler<DeletePhoneCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePhoneCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePhoneCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Phones.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            _context.Phones.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
