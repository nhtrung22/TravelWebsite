using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWebsite.DataAccess.DTO;

namespace TravelWebsite.Business.Common.Interfaces
{
    public interface ICityService
    {
        Task<List<CityDTO>> Get();
    }
}
