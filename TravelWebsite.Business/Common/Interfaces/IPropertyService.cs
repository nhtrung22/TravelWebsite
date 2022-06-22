using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.Commands.CreatePlace;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IPropertyService
    {
        Task<int> Create(CreatePropertyCommand request);
        Task Update(int id, UpdatePropertyCommand place);
        Task<PaginatedList<PropertyDTO>> Get(GetPropertiesQuery request);
        Task<List<PropertyByCityDTO>> GetByCity();
        Task<PaginatedList<PropertyDTO>> GetByCurrentUser(GetPropertiesQuery request);
        Task<PropertyDTO> Get(int id);
        Task Delete(int id);
    }
}
