using System.Collections.Generic;
using SwappBackend.Models;
using SwappBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SwappBackend.Controllers
{
    [Route("api/public/[controller]")]
    public partial class UsersController
    {

        [HttpGet("{username}")]
        public ActionResult<ResponseItem> Get(string username)
        {
            User user = _userService.GetByUsername(username);

            if (user == null)
                return new ResponseItem("error", "Utilizatorul nu exista.");

            return new ResponseItem("success", user);
        }

        [HttpPost("login")]
        public ActionResult<ResponseItem> Login([FromForm]string username, [FromForm]string password)
        {
            if (username == null || password == null || username.Length == 0 || password.Length == 0)
                return new ResponseItem("error", "Utilizatorul sau parola este gresita.");

            User logginedUser = _userService.Login(username, password);
            
            if(logginedUser==null)
                 return new ResponseItem("error", "Utilizatorul sau parola este gresita.");

            return new ResponseItem("success", Program.secretTokenKey + "_" + logginedUser.Id + "_" + DateTime.Now.AddDays(3).ToString());
        }
        [HttpPost("signup")]
        public ActionResult<ResponseItem> Signup(User user)
        {
            string signupError = _userService.Create(user);
            return Program.GetResponseItemFromError(signupError, "Te-ai inregistrat cu success");

        }
        
    }
}
