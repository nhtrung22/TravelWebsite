using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid? ValidateJwtToken(string token);
        public RefreshToken GenerateRefreshToken(string ipAddress);
     
    }
}
