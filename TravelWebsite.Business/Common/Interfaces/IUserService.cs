using TravelWebsite.Business.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(Guid id);

    }
}
