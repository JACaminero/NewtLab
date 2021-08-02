using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewtlabAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
