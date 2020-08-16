using code_test_contacts_api.Application.Common.Exceptions;
using code_test_contacts_api.Application.Contact.Commands;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.Contact.Commands
{
    using static Testing;

    public class UpdateContactTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateContact()
        {
            var userId = await RunAsDefaultUserAsync();

            var contactID = await SendAsync(new CreateContactCommand
            {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
               
            });

            var command = new UpdateContactCommand
            {
                Id = contactID,
                Title = "Updated List Title",
                FirstName = "Bat",
                LastName = "Man",
            };

            await SendAsync(command);

            var list = await FindAsync<Domain.Entities.Contact>(contactID);

            list.Title.Should().Be(command.Title);

        }
    }
}
