
using UserProject.Models;
using UserProject.Models.DTO;

namespace UserProject.Services
{
    public interface IUsersAttemptService
    {
        Task<UsersAttempts> Create(string email);
        Task UpdateStatus(string id, bool sent);
    }
}
