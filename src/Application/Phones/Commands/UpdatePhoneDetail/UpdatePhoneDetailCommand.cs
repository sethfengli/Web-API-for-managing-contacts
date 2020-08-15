using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Phones.Commands
{
    public class UpdatePhoneDetailCommand : IRequest
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class UpdatePhoneDetailCommandHandler : IRequestHandler<UpdatePhoneDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePhoneDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePhoneDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Phones.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            entity.ContactId = request.ContactId;
            entity.PhoneNumber = request.PhoneNumber;
 
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
