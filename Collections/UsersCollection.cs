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

        public async Task AddUser(string username,string password,string mail)
        {
            var vacio = new List<string>();
            await collection.InsertOneAsync(new User
            {
                nickname = username,
                password = password,
                mail = mail,
                age = 0,
                avatar = "https://i.ibb.co/7vYwcGP/Xiahel.png",
                rol = "6272d0128c7c6d405e2456ea",
                descripcion = "",
                favm = vacio.ToArray(),
                favn = vacio.ToArray()
            }, null);
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

        public async Task UpdateUserAge(string id, Int32 age)
        {
            var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.age, age));
        }

        public async Task UpdateUserDesc(string id,string desc)
        {

            var update = await collection.UpdateOneAsync(user=>user.id==id,Builders<User>.Update.Set(u=>u.descripcion,desc));
           
        }

        public async Task UpdateUserFavm(string id, string movie)
        {
            var listaNueva = new List<string>();
            var favm = await collection.FindAsync<User>(user => user.id == id).Result.FirstOrDefaultAsync();
            if(favm.favm.Count() <= 0)
            {
                listaNueva.Add(movie);
                var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.favm, listaNueva.ToArray()));
            }
            else
            {
                listaNueva = favm.favm.ToList();
                if (!listaNueva.Contains(movie))
                {
                    listaNueva.Add(movie);
                    var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.favm, listaNueva.ToArray()));
                    listaNueva.Clear();
                }
                
            }
        }
        public async Task UpdateUserFava(string id, string anime)
        {
            var listaNueva = new List<string>();
            var fav = await collection.FindAsync<User>(user => user.id == id).Result.FirstOrDefaultAsync();
            if (fav.favn.Count() <= 0)
            {
                listaNueva.Add(anime);
                var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.favn, listaNueva.ToArray()));
                listaNueva.Clear();
            }
            else
            {
                listaNueva = fav.favn.ToList();
                if (!listaNueva.Contains(anime))
                {
                    listaNueva.Add(anime);
                    var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.favn, listaNueva.ToArray()));
                    listaNueva.Clear();
                }
            }
        }

        public async Task UpdateUserMail(string id, string mail)
        {
            var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.mail, mail));
        }

        public async Task UpdateUserNick(string id, string name)
        {
            var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.nickname, name));
        }

        public async Task UpdateUserPass(string id, string pass)
        {
            var update = await collection.UpdateOneAsync(user => user.id == id, Builders<User>.Update.Set(u => u.password, pass));
        }

        public async Task<User> GetUserByName(string name)
        {
            var res = await collection.FindAsync<User>(u => u.nickname.ToLower() == name.ToLower()).Result.FirstOrDefaultAsync();
            return res;
        }
    }
}
