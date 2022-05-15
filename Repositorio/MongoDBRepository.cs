using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_C;

namespace API_C.Repositorio
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase _db;
        public MongoDBRepository()
        {
            client = new MongoClient(Env.MONGODB_CLUSTER);
            _db = client.GetDatabase(Env.MONGODB_NAME);
        }
    }
}
