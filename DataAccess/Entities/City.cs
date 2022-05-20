using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class City
    {
        [Key]
        public int CityID { get; set; } // PK

        public string CityName { get; set; }

        public string Description { get; set; }


        // City - Place
        public ICollection<Place> Places { get; set; }

    }
}
