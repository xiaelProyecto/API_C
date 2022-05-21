using API_C.Collections;
using API_C.ICollections;
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
    public class AnimeController : Controller
    {
        private IAnimeCollection _db = new AnimeCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllAnimes()
        {
            var result = await _db.GetAllAnimes();
            if (result.Count() < 0) return BadRequest();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeById(string id)
        {
            var result = await _db.GetAnimeById(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(string id)
        {
            await _db.DeleteAnime(id);
            return NoContent();
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> SearchService(string name)
        {
            var result = await _db.GetAnimeByName(name);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
