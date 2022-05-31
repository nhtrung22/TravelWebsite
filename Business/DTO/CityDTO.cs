using TW.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.DataAccess.DTO
{
    public class CityDTO
    {

        public string CityName { get; set; }

        public string Description { get; set; }


        // City - Place
        public ICollection<Place> Places { get; set; }

    }
}
