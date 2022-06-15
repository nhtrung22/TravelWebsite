using Microsoft.AspNetCore.Http;
using TravelWebsite.Business.Common.Interfaces;

namespace TravelWebsite.Business.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext.Items["Id"];
                if (userId == null) return Guid.Empty;
                return new Guid(userId.ToString());
            }
        }
    }
}
