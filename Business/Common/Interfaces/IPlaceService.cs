using TW.DataAccess.DTO;
using TW.DataAccess.Entities;

namespace TW.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> Get();

        //Task<List<PlaceDTO>> GetAsysnc(int id);

        Task CreatePlace(PlaceDTO placeDto);

        Task<List<PlaceDTO>> SortDescending();

    }
}
