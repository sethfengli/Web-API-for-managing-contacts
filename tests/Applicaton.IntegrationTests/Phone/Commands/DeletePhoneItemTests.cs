using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Phones.Commands;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using code_test_contacts_api.Application.Contact.Commands;

namespace code_test_contacts_api.Application.IntegrationTests.Phones.Commands
{
    using static Testing;

    public class DeletePhoneItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidPhone()
        {
            var command = new DeletePhoneCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeletePhone()
        {
            var contactId = await SendAsync(new CreateContactCommand
            {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
    
            });

            var itemId = await SendAsync(new CreatePhoneCommand
            {
                ContactId = contactId,
                PhoneNumber = "New phone number"
            });

            await SendAsync(new DeletePhoneCommand
            {
                Id = itemId
            });

            var list = await FindAsync<Phone>(itemId);

            list.Should().BeNull();
        }
    }
}
