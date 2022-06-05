using TravelWebsite.Business.DTO;

namespace TravelWebsite.Business.Context
{
    public class TravelWebsiteUserContext : ITravelWebsiteUserContext
    {
        public readonly IHttpContextAccessor _httpContext;
        public TravelWebsiteUserContext(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UserDTO user
        {
            get
            {
                return (UserDTO)_httpContext.HttpContext.Items["User"];
            }
            set { this.user = value; }
        }
    }
}
