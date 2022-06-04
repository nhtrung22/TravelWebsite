using TravelWebsite.Business.DTO;

namespace TravelWebsite.Business.Context
{
    public interface ITravelWebsiteUserContext
    {
        UserDTO user { get; set; }
    }
}
