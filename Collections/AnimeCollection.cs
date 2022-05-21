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
    public class AnimeCollection : IAnimeCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Anime> collection;

        public AnimeCollection()
        {
            collection = _repository._db.GetCollection<Anime>(Env.C_ANIMES);
        }
        public async Task DeleteAnime(string id)
        {
            var res = await collection.DeleteOneAsync(movie => movie.id == id);
        }

        public async Task<List<Anime>> GetAllAnimes()
        {
            var animes = await collection.FindAsync(anime => true).Result.ToListAsync();
            return animes;
        }

        public async Task<Anime> GetAnimeById(string id)
        {
            var anime = await collection.FindAsync<Anime>(anime => anime.id == id).Result.FirstAsync();
            return anime;
        }
        public async Task<Anime> GetAnimeByName(string name)
        {
            var anime = await collection.FindAsync<Anime>(a => a.titulo == name).Result.FirstAsync();
            return anime;
        }
    }
}
