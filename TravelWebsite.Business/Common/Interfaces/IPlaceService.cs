using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.Commands.CreatePlace;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<int> Create(CreatePlaceCommand request);
        Task Update(int id, UpdatePlaceCommand place);
        Task<PaginatedList<PlaceDTO>> Get(GetPlacesQuery request);
        Task<PaginatedList<PlaceDTO>> GetByCurrentUser(GetPlacesQuery request);
        Task<PlaceDTO> Get(int id);
        Task Delete(int id);
    }
}
