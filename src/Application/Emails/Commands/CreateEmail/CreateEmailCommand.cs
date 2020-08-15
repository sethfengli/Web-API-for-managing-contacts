using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Emails.Commands
{
    public class CreateEmailCommand : IRequest<int>
    {
        public int ContactId { get; set; }

        public string EmailAddress { get; set; }
    }

    public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
        {
            var entity = new Email
            {
                ContactId = request.ContactId,
                EmailAddress = request.EmailAddress,
            };
            
            _context.Emails.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
