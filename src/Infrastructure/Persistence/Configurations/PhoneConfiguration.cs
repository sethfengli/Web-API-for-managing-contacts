using code_test_contacts_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace code_test_contacts_api.Infrastructure.Persistence.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(t => t.PhoneNumber).HasMaxLength(20).IsRequired();
        }
    }
}
