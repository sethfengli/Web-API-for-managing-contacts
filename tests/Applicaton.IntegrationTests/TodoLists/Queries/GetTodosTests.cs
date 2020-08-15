using code_test_contacts_api.Application.Contact.Queries;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.TodoLists.Queries
{
    using static Testing;

    public class GetTodosTests : TestBase
    {
        [Test]
        public async Task ShouldReturnPriorityLevels()
        {
            var query = new GetContactQuery();

            var result = await SendAsync(query);

            result.Gender.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldReturnAllListsAndItems()
        {
            await AddAsync(new Domain.Entities.Contact
            {
                Title = "Mr",
                FirstName = "James",
                LastName = "Bond",
                Phones =
                    {
                        new Phone { PhoneNumber = "007" },
                        new Phone { PhoneNumber = "007 + 1" },
                    },
                Emails =
                    {
                        new Email { EmailAddress = "007@james.bond" },
                        new Email { EmailAddress = "j.bond@007.com" },
                    }
            });

            var query = new GetContactQuery();

            var result = await SendAsync(query);

            result.Contacts.Should().HaveCount(1);
            
        }
    }
}
