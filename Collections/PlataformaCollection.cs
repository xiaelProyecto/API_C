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
    public class PlataformaCollection : IPlataformaCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Plataforma> collection;
        public PlataformaCollection()
        {
            collection = _repository._db.GetCollection<Plataforma>(Env.C_PLATAFORMAS);
        }
        public async Task<List<Plataforma>> GetPlataforms()
        {
            var plataformas = await collection.FindAsync(p => true).Result.ToListAsync();

            return plataformas;
        }
    }
}
