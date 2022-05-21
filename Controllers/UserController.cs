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
    public class UserController : Controller
    {
        private IUsersCollection _db = new UsersCollection();
        private IRolesCollection _aux = new RolesCollection();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _db.GetAllUsers();
            if (result.Count() < 0) return BadRequest();
            foreach (var u in result)
            {
                var format = await _aux.GetRol(u.rol);
                u.rol = format.rol;
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _db.GetUserById(id);
            var format = await _aux.GetRol(result.rol);
            if (result == null || format == null) return BadRequest();
            result.rol = format.rol;
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
            await _db.DeleteUser(id);
            return Ok();
        }

    }
}
