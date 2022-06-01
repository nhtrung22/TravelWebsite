namespace TravelWebsite.DataAccess.JwtModel;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}