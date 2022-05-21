using API_C.Collections;
using API_C.ICollections;
using API_C.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class MovieController : Controller
    {
        private IMoviesCollection _db = new MoviesCollection();
        private IPlataformaCollection _aux = new PlataformaCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllMovies() {
            var listaPlataformas = new List<string>();
            var result = await _db.GetAllMovies();
            var plataformas = await _aux.GetPlataforms();
            if (result.Count < 0 && plataformas.Count < 0) return BadRequest();
            foreach(var r in result)
            {
                foreach(var p in r.plataformas)
                {
                    var plataforma = plataformas.Where(pid => pid.id == p).Select(name => name.nombre).FirstOrDefault();
                    listaPlataformas.Add(plataforma);
                }
                r.plataformas = listaPlataformas.ToArray();
                listaPlataformas.Clear();
            }
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(string id)
        {
            var result = await _db.GetMovieById(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            await _db.DeleteMovie(id);
            return NoContent();
        }

        
        [HttpGet("{name}")]
        public async Task<IActionResult> SearchService(string name)
        {
            var result = await _db.GetMovieByName(name);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
