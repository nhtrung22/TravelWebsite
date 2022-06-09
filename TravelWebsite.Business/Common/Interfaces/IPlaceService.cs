using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities.Paging;
using TravelWebsite.DataAccess.Helpers;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<PlaceDTO> Create(Place place);
        PageList<PlaceDTO> Get(PlaceParametes placeParametes);
        Task<int> Delete(int Id);
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);
    }
}
