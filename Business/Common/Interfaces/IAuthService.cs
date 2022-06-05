namespace TravelWebsite.Business.Services;

using TravelWebsite.Business.DTO;
using TravelWebsite.Business.JwtModel;
using TravelWebsite.DataAccess.Entities.JwtModel;

public interface IAuthService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
    AuthenticateResponse RefreshToken(string token, string ipAddress);
    void RevokeToken(string token, string ipAddress);
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(Guid id);
}