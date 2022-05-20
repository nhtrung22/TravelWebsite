using DataAccess.DTO;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> GetAllAsysnc();

        //Task<List<PlaceDTO>> GetAsysnc(int id);
        Task CreatePlace(PlaceDTO placeDto);

    }
}
