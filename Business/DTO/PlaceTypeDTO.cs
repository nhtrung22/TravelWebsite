using TW.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.DataAccess.DTO
{
    public class PlaceTypeDTO
    {

        public string Name { get; set; }

        public string Description { get; set; }

        // PlaceType - Place
        public ICollection<Place> Places { get; set; }

    }
}
