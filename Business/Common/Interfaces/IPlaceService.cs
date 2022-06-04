using TravelWebsite.Business.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> Get();

        Task CreatePlace(PlaceDTO placeDto);

    }
}
