using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelWebsite.Jwt
{
    public class AutheResultModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
