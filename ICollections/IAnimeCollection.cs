using API_C.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.ICollections
{
    interface IAnimeCollection
    {
        Task<List<Anime>> GetAllAnimes();
        Task<Anime> GetAnimeById(string id);
        Task DeleteAnime(string id);
    }
}
