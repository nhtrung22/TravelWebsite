using TravelWebsite.DataAccess.DTO;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> Get();

        Task CreatePlace(PlaceDTO placeDto);

    }
}
