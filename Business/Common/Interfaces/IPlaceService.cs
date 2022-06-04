using TravelWebsite.Business.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);

        Task CreatePlace(PlaceDTO placeDto);

    }
}
