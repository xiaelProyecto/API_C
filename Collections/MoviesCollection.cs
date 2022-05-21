using API_C.Model;
using API_C.Repositorio;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Collections
{
    public class MoviesCollection : IMoviesCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Movie> collection;
        public MoviesCollection()
        {
            collection = _repository._db.GetCollection<Movie>(Env.C_MOVIES);
        }
        
        public async Task DeleteMovie(string id)
        {
            var res = await collection.DeleteOneAsync(movie=>movie.id==id);
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            var movies =  await collection.FindAsync(movies=>true).Result.ToListAsync();
            
            return movies;
        }

        public async Task<Movie> GetMovieById(string id)
        {
            var movie = await collection.FindAsync<Movie>(movie => movie.id == id).Result.FirstAsync();
            return movie; 
        }
        
        public async Task<Movie> GetMovieByName(string name)
        {
            var movie = await collection.FindAsync<Movie>(movie => movie.titulo == name).Result.FirstAsync();
            return movie;
        }
    }
}
