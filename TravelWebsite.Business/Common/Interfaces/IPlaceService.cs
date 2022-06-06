using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task Create(PlaceDTO placeDto);
        Task<List<PlaceDTO>> Get();
        //Task<PlaceDTO> Update(int Id, PlaceDTO NewPlace);
        Task<int> Delete(int Id);
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);
    }
}
