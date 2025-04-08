using UserProject.Models;

namespace UserProject.Repositories
{
    public interface IUsersAttemptRepository
    {
        Task<UsersAttempts> Create(UsersAttempts attempt);
    }
}
