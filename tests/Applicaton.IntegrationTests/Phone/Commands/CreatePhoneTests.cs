using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Phones.Commands;
using code_test_contacts_api.Application.Contact.Commands;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.Phones.Commands
{
    using static Testing;

    public class CreatePhoneTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreatePhoneCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreatePhone()
        {
            var userId = await RunAsDefaultUserAsync();

            var contactId = await SendAsync(new CreateContactCommand
            {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
            
            });

            var command = new CreatePhoneCommand
            {
                ContactId = contactId,
                PhoneNumber = "1232344345"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Phone>(itemId);

            item.Should().NotBeNull();
            item.ContactId.Should().Be(command.ContactId);
            item.PhoneNumber.Should().Be(command.PhoneNumber);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
