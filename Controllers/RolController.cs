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
    public class RolController : Controller
    {
        private IRolesCollection _db = new RolesCollection();
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(string id)
        {
            var result = await _db.GetRol(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
