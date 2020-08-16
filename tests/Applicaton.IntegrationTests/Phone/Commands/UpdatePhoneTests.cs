using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Phones.Commands;
using code_test_contacts_api.Application.Contact.Commands;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace code_test_contacts_api.Application.IntegrationTests.Phones.Commands
{
    using static Testing;

    public class UpdatePhoneTests : TestBase
    {
        [Test]
        public void ShouldRequireValidPhone()
        {
            var command = new UpdatePhoneCommand
            {
                Id = 99,
                PhoneNumber = "New phone"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdatePhone()
        {
            var userId = await RunAsDefaultUserAsync();

            var contactId = await SendAsync(new CreateContactCommand
            {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
            });

            var itemId = await SendAsync(new CreatePhoneCommand
            {
                ContactId = contactId,
                PhoneNumber = "New phone"
            });

            var command = new UpdatePhoneCommand
            {
                Id = itemId,
                PhoneNumber = "Updated phone number"
            };

            await SendAsync(command);

            var item = await FindAsync<Phone>(itemId);

            item.PhoneNumber.Should().Be(command.PhoneNumber);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
