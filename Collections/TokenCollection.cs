using API_C.ICollections;
using API_C.Model;
using API_C.Repositorio;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace API_C.Collections
{
    public class TokenCollection : ITokenCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Mytoken> collection;
        public TokenCollection()
        {
            collection = _repository._db.GetCollection<Mytoken>(Env.C_TOKENS);
        }
        public async Task<Mytoken> GetToken()
        {
            var response = await collection.FindAsync<Mytoken>(t=>true).Result.FirstAsync();
            return response; 
        }
    }
}
