using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Phones.Commands
{
    public class CreatePhoneCommand : IRequest<int>
    {
        public int ContactId { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePhoneCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        {
            var entity = new Phone
            {
                ContactId = request.ContactId,
                PhoneNumber = request.PhoneNumber,
            };
            
            _context.Phones.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
