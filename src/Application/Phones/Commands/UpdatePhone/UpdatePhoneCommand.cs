using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Phones.Commands
{
    public partial class UpdatePhoneCommand : IRequest
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class UpdatePhoneCommandHandler : IRequestHandler<UpdatePhoneCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePhoneCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Phones.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Phone), request.Id);
            }

            entity.PhoneNumber = request.PhoneNumber;
         
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
