using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Emails.Commands
{
    public partial class UpdateEmailCommand : IRequest
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }
    }

    public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Emails.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            entity.EmailAddress = request.EmailAddress;
         
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
