using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Models.Jwt;

using System.Text.Json.Serialization;

public class AuthenticateResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string JwtToken { get; set; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; set; }

    public AuthenticateResponse(User user, string jwtToken, string refreshToken)
    {
        Id = user.Id;
        UserName = user.UserName;
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }
}