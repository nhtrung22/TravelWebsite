using DataAccess.DTO;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsysnc();

        Task<UserDTO> Add(UserDTO user);

        Task<UserDTO> Update(UserDTO user);

        Task<UserDTO> Login(string userName, string password);

        Task Remove(string email);

        //Task CreatePlace(PlaceDTO placeDto);

        //Task<List<PlaceDTO>> SortDescending();

    }
}
