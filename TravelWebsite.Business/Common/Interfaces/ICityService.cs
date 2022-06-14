using TravelWebsite.DataAccess.Models.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface ICityService
    {
        Task<List<CityDTO>> Get();
    }
}
