using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        // POST api/Users
        [Route("login")]
        [HttpPost]
        public string Post([FromForm] string username, [FromForm] string password)
        {
            User user = DB.Login(username, password);

            if (user == null)
                return "{\"status\":\"error\",\"message\":\"Username or password is incorrect.\"}";

            string token = AuthService.GenerateToken(user);

            return "{\"status\":\"success\",\"token\":\""+ token + "\"}";
        }
    }
}
