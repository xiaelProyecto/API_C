using API_C.Collections;
using API_C.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MovieController : Controller
    {
        private IMoviesCollection _db = new MoviesCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllMovies() {
            var result = await _db.GetAllMovies();
            if (result.Count() < 0) return BadRequest();
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

    }
}
