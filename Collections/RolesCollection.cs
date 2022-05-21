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
    public class RolesCollection : IRolesCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Roles> collection;
        public RolesCollection()
        {
            collection = _repository._db.GetCollection<Roles>(Env.C_ROLES);
        }
        public async Task<Roles> GetRol(string id)
        {
            var rol = await collection.FindAsync<Roles>(rol => rol.id == id).Result.FirstAsync();
            return rol;
        }
    }
}
