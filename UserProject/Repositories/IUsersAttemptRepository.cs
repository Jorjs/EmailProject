using MongoDB.Driver;
using UserProject.Models;

namespace UserProject.Repositories
{
    public interface IUsersAttemptRepository
    {
        Task<UsersAttempts> Create(UsersAttempts attempt);

        Task<UpdateResult> UpdateStatus(string id, bool status);
    }
}
