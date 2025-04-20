using UserProject.Models;
using MongoDB.Driver;
using MongoDB.Bson;

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

        public async Task<UpdateResult> UpdateStatus(string id, bool status)
        {
            var filter = Builders<UsersAttempts>.Filter.Eq(u => u._id, id);
            var update = Builders<UsersAttempts>.Update.Set(u => u.Sent, status);

            return await _collection.UpdateOneAsync(filter, update);
        }
    }
}
