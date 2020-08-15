
using code_test_contacts_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace code_test_contacts_api.Infrastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(20);
            builder.Property(t => t.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(100).IsRequired();

        }
    }
}
