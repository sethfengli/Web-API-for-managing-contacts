using code_test_contacts_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Contact> Contacts { get; set; }

        DbSet<Phone> Phones { get; set; }

        DbSet<Email> Emails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
