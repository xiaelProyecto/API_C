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
    public class UserController : Controller
    {
        private IUsersCollection _db = new UsersCollection();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _db.GetAllUsers();
            if (result.Count() < 0) return BadRequest();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _db.GetUserById(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
            await _db.DeleteUser(id);
            return Ok();
        }

    }
}
