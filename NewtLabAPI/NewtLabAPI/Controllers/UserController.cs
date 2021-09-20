using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtlabAPI.Services;
using NewtlabAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NewtlabAPI.Controllers
{
    [Route("newtlabapi/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate(AuthenticationModel am)
        {
            var response = _userService.Authenticate(am.Username, am.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet("users")]
        public IActionResult GetAllWithRole()
        {
            return Ok(_userService.GetAllWithRole());
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody]User user)
        {
            if (user == null)
                return BadRequest(new { message = "Datos invalidos" });

            user = _userService.ValidateRole(user);
            _userService.Insert(user);
            
            return Ok(new { message = $"Exito. {user}"});
        }
    }
}
