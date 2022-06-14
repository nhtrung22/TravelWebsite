namespace TravelWebsite.Business.Services;

using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Jwt;
using TravelWebsite.DataAccess.Entities;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(Guid id);
    Task Update(Guid id, UpdateRequest model);
    Task<User> Create(User user, string password);
    Task Delete(Guid id);
}