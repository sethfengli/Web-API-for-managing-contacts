using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Contact.Commands;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class UpdateTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new UpdateContactCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldRequireUniqueTitle()
        {
            var listId = await SendAsync(new CreateContactCommand
            {
                Title = "New List"
            });

            await SendAsync(new CreateContactCommand
            {
                Title = "Other List"
            });

            var command = new UpdateContactCommand
            {
                Id = listId,
                Title = "Other List"
            };

            FluentActions.Invoking(() =>
                SendAsync(command))
                    .Should().Throw<ValidationException>().Where(ex => ex.Errors.ContainsKey("Title"))
                    .And.Errors["Title"].Should().Contain("The specified title already exists.");
        }

        [Test]
        public async Task ShouldUpdateTodoList()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateContactCommand
            {
                Title = "New List"
            });

            var command = new UpdateContactCommand
            {
                Id = listId,
                Title = "Updated List Title"
            };

            await SendAsync(command);

            var list = await FindAsync<Domain.Entities.Contact>(listId);

            list.Title.Should().Be(command.Title);
            list.LastModifiedBy.Should().NotBeNull();
            list.LastModifiedBy.Should().Be(userId);
            list.LastModified.Should().NotBeNull();
            list.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
