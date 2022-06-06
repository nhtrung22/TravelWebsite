using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // PK

        public string UserName { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public UserType UserType { get; set; }

        // public int? Status { get; set; } // specific status enum

 
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
