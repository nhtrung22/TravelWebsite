using TravelWebsite.Business.DTO;
using TravelWebsite.Business.Helpers;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities.Paging;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<PlaceDTO> Create(Place place);
        Task<PagedList<PlaceDTO>> Get(PlaceParametes placeParametes);
        Task<int> Delete(int Id);
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);
    }
}
