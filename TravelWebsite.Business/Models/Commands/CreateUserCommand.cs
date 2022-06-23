using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.Business.Models.Commands
{
    public class CreateUserCommand
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType? UserType { get; set; }
    }
}