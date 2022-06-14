namespace TravelWebsite.Business.Services;

using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Jwt;

public interface IAuthService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
    AuthenticateResponse RefreshToken(string token, string ipAddress);
    void RevokeToken(string token, string ipAddress);
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(Guid id);
}