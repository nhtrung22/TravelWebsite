namespace TravelWebsite.Business.Services;

using BCrypt.Net;
using Microsoft.Extensions.Options;
using TravelWebsite.Business.Helpers;


using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities.JwtModel;
using TravelWebsite.Business.JwtModel;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
    AuthenticateResponse RefreshToken(string token, string ipAddress);
    void RevokeToken(string token, string ipAddress);
    IEnumerable<User> GetAll();
    User GetById(Guid id);
}