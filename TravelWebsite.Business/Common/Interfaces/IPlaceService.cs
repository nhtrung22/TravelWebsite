using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<PlaceDTO> Create(PlaceDTO place);
        Task Update(int id, PlaceDTO place);
        Task<PaginatedList<PlaceDTO>> Get(GetPlacesQuery request);
        Task<int> Delete(int Id);
    }
}
