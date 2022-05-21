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
        Task UpdateUserDesc(string id,string desc);
        Task UpdateUserAge(string id, Int32 age);
        Task UpdateUserMail(string id, string mail);
        Task UpdateUserNick(string id, string name);

        Task UpdateUserPass(string id, string pass);
        Task UpdateUserFavm(string id, string movie);
        Task UpdateUserFava(string id, string anime);

    }
}
