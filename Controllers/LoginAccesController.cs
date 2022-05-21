using API_C.Model;
using API_C.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using API_C.ICollections;
using API_C.Collections;

namespace API_C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginAccesController : Controller
    {
        internal MongoDBRepository _collections = new MongoDBRepository();
        private ITokenCollection _token = new TokenCollection();
        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> Login(string username,string password)
        {
            var users =  _collections._db.GetCollection<User>(Env.C_USERS);
            var result = users.FindAsync<User>(u => u.nickname.ToLower() == username.ToLower() && u.password == password).Result.FirstOrDefault();
            if (result == null) return NotFound("Usuario o Contraseña incorrecta");
            var res = await _token.GetToken();
            if (res == null) return Forbid("Falla con el servidor");
            var model = new LoginData {
                id = result.id,
                token = res.token,
            };
            
            return Ok(model);
        }


    }
}
