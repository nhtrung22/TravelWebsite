using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace TravelWebsite.DataAccess.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } // PK

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        //public string Token { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int UserType { get; set; }

        public int Status { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

    }
}
