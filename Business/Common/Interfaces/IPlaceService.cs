using TravelWebsite.DataAccess.DTO;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> Get();

        //Task<List<PlaceDTO>> GetAsysnc(int id);

        Task CreatePlace(PlaceDTO placeDto);

        Task<List<PlaceDTO>> SortDescending();

    }
}
