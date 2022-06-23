using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.Business.Models.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public int Age { get; set; } = default!;
        public UserType UserType { get; set; }
    }
}
