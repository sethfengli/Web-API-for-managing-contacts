using AutoMapper;
using AutoMapper.QueryableExtensions;
using code_test_contacts_api.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Queries
{
    public class ExportContactsQuery : IRequest<ExportContactVm>
    {
        public int Id { get; set; }
    }

    public class ExportTodosQueryHandler : IRequestHandler<ExportContactsQuery, ExportContactVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportTodosQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportContactVm> Handle(ExportContactsQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportContactVm();

            var records = await _context.Contacts
                    .Where(t => t.Id == request.Id)
                    .ProjectTo<ContactRecord>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildContactFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = "TodoItems.csv";

            return await Task.FromResult(vm);
        }
    }
}
