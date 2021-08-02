using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtlabAPI.Models;
using System.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using NewtlabAPI.Data;
using NewtlabAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace NewtlabAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(string username, string password);
        IEnumerable<User> GetAllWithRole();
        User GetById(int id);
    }
    
    public class UserService: IUserService
    {
        private readonly NewtLabContext db = new NewtLabContext();
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(string username, string password)
        {
            var user = GetAllWithRole().SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAllWithRole()
        {
            var users = db.Users.ToList();
            var roles = db.Roles.ToList();
            return users.Join(roles,
                user => user.Role.RoleId,
                role => role.RoleId,
                (user, role) => new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password,
                    Role = role
                });
        }

        public User GetById(int id)
        {
            return db.Users.SingleOrDefault(user => user.UserId == id);
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("zhvyOBxiyOTZg+eBOMGRG4VAp86kGM1ZlL87Psby2JP6697VKKN9uyE/oRdHS4Nyy2FmqD9nrVipTpZ1nrOpH67rXSJkRZ8mQ7GCNPaLHm+v/dH/4g5WAwAwyPLTfUuD55C7AFLxk8baedPQdTQd3V0R/kmbMDceMlGrwYF0+8XROAKR7CDHSDFdOffi8JwDVKWxw+XW7deEalQiH2RYB10MVhFJ+AVKeTs39J4VPRziwmy0gKSNAUdqp3srMX1M1L7uopxP5usaER+uu1eZyxAX0PTT+1j8Nfiht5/iz9Tl4aWL0NFNz5N15nzoR4MTUz2DgA8e7e5scOzC3kAQYA==");
            var symkey = new SymmetricSecurityKey(key);
            var tokenDescriptor = new SecurityTokenDescriptor() 
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("id", user.UserId.ToString()),
                    new Claim("role", user.Role.Description)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(symkey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
