using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Contact.Commands;

using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.Contact.Commands
{
    using static Testing;

    public class DeleteContactTests : TestBase
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
            var contactId = await SendAsync(new CreateContactCommand
            {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
              
            });

            await SendAsync(new DeleteContactCommand 
            { 
                Id = contactId 
            });

            var contact = await FindAsync<Domain.Entities.Contact>(contactId);

            contact.Should().BeNull();
        }
    }
}
