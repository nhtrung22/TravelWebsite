using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<PlaceDTO> Create(PlaceDTO place);
        Task Update(int id, PlaceDTO place);
        Task<PagedList<PlaceDTO>> Get(GetPlacesQuery request);
        Task<int> Delete(int Id);
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);
    }
}
