using code_test_contacts_api.Application.Common.Models;
using System.Threading.Tasks;

namespace code_test_contacts_api.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
