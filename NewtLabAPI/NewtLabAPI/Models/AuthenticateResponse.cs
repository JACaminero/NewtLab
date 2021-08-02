using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.UserId;
            Username = user.Username;
            Role = user.Role.Description;
            Token = token;
        }
    }
}