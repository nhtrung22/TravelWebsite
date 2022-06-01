using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWebsite.Jwt;

namespace TravelWebsite.Jwt
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(LoginModel model);
    }
}
