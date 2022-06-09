using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<PlaceDTO> Create(Place place);
        Task<List<PlaceDTO>> Get();
        Task<int> Delete(int Id);
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);
    }
}
