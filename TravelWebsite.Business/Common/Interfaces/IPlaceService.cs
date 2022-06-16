using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<int> Create(CreatePlaceCommand request);
        Task Update(int id, UpdatePlaceCommand place);
        Task<PaginatedList<PlaceDTO>> Get(GetPlacesQuery request);
        Task Delete(int id);
    }
}
