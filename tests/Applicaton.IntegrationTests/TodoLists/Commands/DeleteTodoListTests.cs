using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Contact.Commands;

using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteContactCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateContactCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteContactCommand 
            { 
                Id = listId 
            });

            var list = await FindAsync<Domain.Entities.Contact>(listId);

            list.Should().BeNull();
        }
    }
}
