using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewtlabAPI.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string LastName1 { get; set; }
        [MaxLength(300)]
        public string LastName2 { get; set; }
        [MaxLength(300)]
        public string Cedula { get; set; }
        [MaxLength(300)]
        public string Phone { get; set; }
        [MaxLength(300)]
        public string Street { get; set; }
        [MaxLength(300)]
        public string HouseNumber{ get; set; }
        [MaxLength(300)]
        public string Sector { get; set; }
        public DateTime Nacimiento { get; set; }
        public User User { get; set; }
    }
}
