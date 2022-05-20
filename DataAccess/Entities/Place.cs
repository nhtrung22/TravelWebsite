using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Place
    {
        [Key]
        public int PlaceID { get; set; } // PK

        public string PlaceName { get; set; } 

        public string Address { get; set; }

        public string ShortDicription { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public string Thumb { get; set; }

        public string Image { get; set; }


        // Place - Place Detail
        public virtual ICollection<PlaceDetail> PlaceDetail { get; set; }

        // Place - Booking
        public int BookingID { get; set; }
        public virtual Booking Booking { get; set; }

        // City - Place
        public int CityID { get; set; }

        public virtual City City { get; set; }

        // PlaceType - Place
        public int PlaceTypeID { get; set; }
        public virtual PlaceType PlaceType { get; set; }
    }
}
