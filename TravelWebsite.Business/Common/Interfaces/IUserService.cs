namespace TravelWebsite.Business.Services;

using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(Guid id);
    Task Update(Guid id, UpdateUserCommand request);
    Task Create(CreateUserCommand request, string password);
    Task Delete(Guid id);
}