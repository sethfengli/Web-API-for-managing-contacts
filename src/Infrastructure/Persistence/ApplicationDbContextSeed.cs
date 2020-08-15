using code_test_contacts_api.Domain.Entities;
using code_test_contacts_api.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace code_test_contacts_api.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Contacts.Any())
            {
                context.Contacts.Add(new Contact
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

                await context.SaveChangesAsync();
            }
        }
    }
}
