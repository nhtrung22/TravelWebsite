using System.ComponentModel.DataAnnotations;

namespace TravelWebsite.Business.JwtModel
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}