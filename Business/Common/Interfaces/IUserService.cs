using TW.DataAccess.DTO;
using TW.DataAccess.Entities;
using TW.DataAccess.EF;

namespace TW.Business.Common.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> Get();

        Task<UserDTO> Add(UserDTO user);

        Task<UserDTO> Update(UserDTO user);

        Task<UserDTO> Login(string userName, string password);

        Task Remove(string email);

        //Task CreatePlace(PlaceDTO placeDto);

        //Task<List<PlaceDTO>> SortDescending();

    }
}
