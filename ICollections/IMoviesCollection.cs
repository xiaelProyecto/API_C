using API_C.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Repositorio
{
    public interface IMoviesCollection
    {
        Task <List<Movie>>GetAllMovies();
        Task<Movie> GetMovieById(string id);
        Task DeleteMovie(string id);
        Task<Movie> GetMovieByName(string name);
    }
}
