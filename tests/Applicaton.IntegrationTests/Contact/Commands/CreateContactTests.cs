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

    public class CreateContactTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateContactCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

       
        [Test]
        public async Task ShouldCreateContact()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateContactCommand
            {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
                Note = "string",
                Sex = 0,
                DateOfBirth = DateTime.Parse("2020-08-15T10:27:37.863Z"),
              
            };

            var id = await SendAsync(command);

            var list = await FindAsync<Domain.Entities.Contact>(id);

            list.Should().NotBeNull();
            list.Title.Should().Be(command.Title);
            list.CreatedBy.Should().Be(userId);
            list.Created.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
