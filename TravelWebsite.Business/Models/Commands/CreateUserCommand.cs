using System.ComponentModel.DataAnnotations;

namespace TravelWebsite.Business.Models.Commands
{
    public class CreateUserCommand
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}