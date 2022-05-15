using API_C.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.ICollections
{
    public interface IUsersCollection 
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task DeleteUser(string id);
        Task AddUser(User user);
        Task UpdateUser(string id);
    }
}
