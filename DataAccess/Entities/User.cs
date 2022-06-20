using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TravelWebsite.DataAccess.Common;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Entities
{
    public class User : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // PK
        public string UserName { get; set; } = default!;
        [JsonIgnore]
        public string PasswordHash { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public UserType UserType { get; set; }
        public ICollection<Booking> Bookings { get; set; } = default!;
        public ICollection<Property> Properties { get; set; } = default!;
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; } = default!;
    }
}
