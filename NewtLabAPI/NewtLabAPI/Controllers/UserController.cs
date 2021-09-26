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

        [HttpGet("get/{id}")]
        public IActionResult GetSingle(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return BadRequest(new { message = "Usuario no exite" });

            return Ok(new
            {
                name = user.Name,
                lastName1 = user.LastName1,
                lastName2 = user.LastName2,
                birth = user.Nacimiento.ToShortDateString(),
                cedula = user.Cedula,
                phone = user.Phone,
                userId = user.UserId,
                username = user.Username
            });
        }

        [HttpGet("users")]
        public IActionResult GetAllWithRole()
        {
            List<object> returnable = new List<object>();
            var users = _userService.GetAllWithRole().ToList();
            foreach (var i in users)
            {
                returnable.Add(new
                {
                    UserId = i.UserId,
                    Username = i.Username,
                    Password = i.Password,
                    Role = i.Role.Description,
                    Name = i.Name,
                    LastName1 = i.LastName1,
                    LastName2 = i.LastName2,
                    Cedula = i.Cedula,
                    Phone = i.Phone,
                    Birth = i.Nacimiento.ToShortDateString(),
                    IsOn = i.IsOn
                });
            }
            return Ok(returnable);
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
        
        [HttpPut("modify")]
        public IActionResult Edit([FromBody] User user)
        {
            if (user == null)
                return BadRequest(new { message = "Datos invalidos" });

            _userService.Modify(user);

            return Ok(new { message = $"Exito." });
        }

        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = $"Exito." });
        }
    }
}
