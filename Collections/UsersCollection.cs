using API_C.ICollections;
using API_C.Model;
using API_C.Repositorio;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Collections
{
    public class UsersCollection : IUsersCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<User> collection;
        public UsersCollection()
        {
            collection = _repository._db.GetCollection<User>(Env.C_USERS);
        }

        public Task AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(string id)
        {
            var res = await collection.DeleteOneAsync(user => user.id == id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await collection.FindAsync(users=>true).Result.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await collection.FindAsync<User>(user => user.id == id).Result.FirstOrDefaultAsync();
            return user;
        }

        public Task UpdateUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
