using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.Commands.CreatePlace;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPropertyService
    {
        Task<int> Create(CreatePlaceCommand request);
        Task Update(int id, UpdatePropertyCommand place);
        Task<PaginatedList<PropertyDTO>> Get(GetPlacesQuery request);
        Task<PaginatedList<PropertyDTO>> GetByCurrentUser(GetPlacesQuery request);
        Task<PropertyDTO> Get(int id);
        Task Delete(int id);
    }
}
