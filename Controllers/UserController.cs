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
        [HttpPost("{username}/{password}/{mail}")]
        public async Task<IActionResult> createUser(string username,string password,string mail)
        {
            var res = await _db.GetUserByName(username);
            if (res!=null) return BadRequest("Usuario existente");
            await _db.AddUser(username, password, mail);
            return Ok();
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
        [HttpPut("{id}/{desc}")]
        public async Task<IActionResult> UpdateUserDesc(string id,string desc)
        {
            await _db.UpdateUserDesc(id, desc);
            return Ok();
        }
        [HttpPut("{id}/{age}")]
        public async Task<IActionResult> UpdateUserAge(string id, Int32 age)
        {
            
            await _db.UpdateUserAge(id, age);
            return Ok();
        }
        [HttpPut("{id}/{name}")]
        public async Task<IActionResult> UpdateUserNick(string id, string name)
        {
            await _db.UpdateUserNick(id, name);
            return Ok();
        }
        [HttpPut("{id}/{mail}")]
        public async Task<IActionResult> UpdateUserMail(string id, string mail)
        {
            await _db.UpdateUserMail(id, mail);
            return Ok();
        }
        [HttpPut("{id}/{pass}")]
        public async Task<IActionResult> UpdateUserPass(string id, string pass)
        {
            await _db.UpdateUserPass(id, pass);
            return Ok();
        }
        [HttpPut("{id}/{movie}")]
        public async Task<IActionResult> UpdateUserFavm(string id, string movie)
        {
            await _db.UpdateUserFavm(id, movie);
            return Ok();
        }
        [HttpPut("{id}/{anime}")]
        public async Task<IActionResult> UpdateUserFava(string id, string anime)
        {
            await _db.UpdateUserFava(id, anime);
            return Ok();
        }
    }
}
