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
    public class PlataformaController : Controller
    {
        private IPlataformaCollection _db = new PlataformaCollection();
        [HttpGet]
        public async Task<IActionResult> GetPlataforms()
        {
            var result = await _db.GetPlataforms();
            if (result.Count < 0) return BadRequest();
            
            return Ok(result);
        }
    }
}
