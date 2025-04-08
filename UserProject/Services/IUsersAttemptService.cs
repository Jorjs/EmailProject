
using UserProject.Models;
using UserProject.Models.DTO;

namespace UserProject.Services
{
    public interface IUsersAttemptService
    {
        Task<UsersAttempts> Create(EmailDto emailInfo);
    }
}
