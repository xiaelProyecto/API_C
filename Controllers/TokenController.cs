using API_C.Collections;
using API_C.ICollections;
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
    public class TokenController : Controller
    {
        private ITokenCollection _db = new TokenCollection();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _db.GetToken();
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
