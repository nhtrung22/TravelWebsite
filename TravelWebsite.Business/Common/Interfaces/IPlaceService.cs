using TravelWebsite.Business.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task Create(PlaceDTO placeDto);
        Task<List<PlaceDTO>> Get();
        //Task<int> Edit(int id);
        Task<int> Delete(int id);
        Task<List<PlaceDTO>> GetPlaceByCity(int CityId);
    }
}
