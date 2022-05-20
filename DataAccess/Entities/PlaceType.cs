using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class PlaceType
    {
        [Key]
        public int PlaceTypeID { get; set; } // PK

        public string PlaceTypeName { get; set; }

        public string PlaceTypeDescription { get; set; }

        // PlaceType - Place
        public ICollection<Place> Places { get; set; }
    }
}
