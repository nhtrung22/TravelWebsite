namespace TravelWebsite.Business.Services;

using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.DTO;
using TravelWebsite.Business.JwtModel;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities.JwtModel;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(Guid id);
    // Task<ActionResult<UserDTO>> Register();

    User Create(User user, string password);
}