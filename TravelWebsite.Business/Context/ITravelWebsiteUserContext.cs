using TravelWebsite.Business.Models.DTO;

namespace TravelWebsite.Business.Context
{
    public interface ITravelWebsiteUserContext
    {
        UserDTO user { get; set; }
    }
}
