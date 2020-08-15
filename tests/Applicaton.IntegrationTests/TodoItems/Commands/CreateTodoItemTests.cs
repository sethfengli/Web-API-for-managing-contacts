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

    public class CreateTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreatePhoneCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var contactId = await SendAsync(new CreatePhoneCommand
            {
                PhoneNumber = "1212121217"
            });

            var command = new CreatePhoneCommand
            {
                ContactId = contactId,
                PhoneNumber = "Tasks"
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
