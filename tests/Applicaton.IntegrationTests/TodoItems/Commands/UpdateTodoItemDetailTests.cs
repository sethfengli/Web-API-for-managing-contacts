using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Phones.Commands;
using code_test_contacts_api.Application.Contact.Commands;
using code_test_contacts_api.Domain.Entities;
using code_test_contacts_api.Domain.Enums;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace code_test_contacts_api.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class UpdateTodoItemDetailTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdatePhoneCommand
            {
                Id = 99,
                PhoneNumber = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateContactCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreatePhoneCommand
            {
                ContactId = listId,
                PhoneNumber = "New Item"
            });

            var command = new UpdatePhoneDetailCommand
            {
                Id = itemId,
                ContactId = listId,
                PhoneNumber = "This is the note.",
               
            };

            await SendAsync(command);

            var item = await FindAsync<Phone>(itemId);

            item.ContactId.Should().Be(command.ContactId);
            item.PhoneNumber.Should().Be(command.PhoneNumber);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
