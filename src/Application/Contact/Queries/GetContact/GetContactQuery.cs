using AutoMapper;
using AutoMapper.QueryableExtensions;
using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Contact.Queries
{
    public class GetContactQuery : IRequest<ContactVm>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetContactQuery, ContactVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactVm> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            return new ContactVm
            {
                Gender = Enum.GetValues(typeof(Gender))
                    .Cast<Gender>()
                    .Select(p => new GenderDto { Value = (int)p, Name = p.ToString() })
                    .ToList(),

                Contacts = await _context.Contacts
                    .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
