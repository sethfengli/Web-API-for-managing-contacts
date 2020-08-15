using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Phones.Commands;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace code_test_contacts_api.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeletePhoneCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreatePhoneCommand
            {
                PhoneNumber = "New List"
            });

            var itemId = await SendAsync(new CreatePhoneCommand
            {
                ContactId = listId,
                PhoneNumber = "New Item"
            });

            await SendAsync(new DeletePhoneCommand
            {
                Id = itemId
            });

            var list = await FindAsync<Domain.Entities.Contact>(listId);

            list.Should().BeNull();
        }
    }
}
