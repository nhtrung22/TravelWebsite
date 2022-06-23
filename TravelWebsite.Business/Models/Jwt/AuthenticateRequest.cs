using System.ComponentModel.DataAnnotations;

namespace TravelWebsite.Business.Models.Jwt;
public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}