using System.Collections.Generic;
using SwappBackend.Models;
using SwappBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SwappBackend.Controllers
{
    [Route("api/private/[controller]")]
    [ApiController]
    public partial class UsersController
    {

        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        
    }
}
