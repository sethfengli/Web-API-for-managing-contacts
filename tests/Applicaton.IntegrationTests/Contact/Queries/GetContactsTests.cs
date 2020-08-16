using code_test_contacts_api.Application.Contact.Queries;
using code_test_contacts_api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.IntegrationTests.Contact.Queries
{
    using static Testing;

    public class GetContactsTests : TestBase
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
                FirstName = "Spider",
                LastName = "Man",
                Phones =
                {
                    new Phone { PhoneNumber = "888888888" },
                    new Phone { PhoneNumber = "+8 888888 " },
                },
                Emails =
                {
                    new Email { EmailAddress = "me@spider.man" },
                    new Email { EmailAddress = "s.man@gmail.com" },
                }
            });
            await AddAsync(new Domain.Entities.Contact
              {
                Title = "Dr",
                FirstName = "Bat",
                LastName = "Man",
                Phones =
                    {
                    new Phone { PhoneNumber = "7717171717" },
                        new Phone { PhoneNumber = "+1 8871717" },
                    },
                Emails =
                    {
                    new Email { EmailAddress = "dr@bat.man" },
                        new Email { EmailAddress = "b.man@gmail.com" },
                    }
            });

            var query = new GetContactQuery();

            var result = await SendAsync(query);

            result.Contacts.Should().HaveCount(2);
            
        }
    }
}
