using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.Business.Models.Commands
{
    public class UpdateUserCommand
    {
        public string UserName { get; set; }

        [EnumDataType(typeof(UserType))]
        public string UserType { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // treat empty string as null for password fields to 
        // make them optional in front end apps
        private string _password;
        [MinLength(6)]
        public string Password
        {
            get => _password;
            set => _password = replaceEmptyWithNull(value);
        }

        private string _confirmPassword;
        [Compare("Password")]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = replaceEmptyWithNull(value);
        }

        // helpers

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}