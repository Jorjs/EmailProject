using UserProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace UserProject.Repositories
{
    public class UsersAttemptRepository : IUsersAttemptRepository
    {
        private readonly IMongoCollection<UsersAttempts> _collection;

        public UsersAttemptRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<UsersAttempts>("UsersAttempts");
        }

        public async Task<UsersAttempts> Create(UsersAttempts attempt)
        {
            await _collection.InsertOneAsync(attempt);
            return attempt;
        }
    }
}
