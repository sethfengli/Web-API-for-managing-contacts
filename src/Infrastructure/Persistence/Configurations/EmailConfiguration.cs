using code_test_contacts_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace code_test_contacts_api.Infrastructure.Persistence.Configurations
{
    class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.Property(t => t.EmailAddress).HasMaxLength(20).IsRequired();
        }
    }
}
