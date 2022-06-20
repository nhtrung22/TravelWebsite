using TravelWebsite.Business.Models.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface ICityService
    {
        Task<List<CityDTO>> Get();
    }
}
