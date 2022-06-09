using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace TravelWebsite.DataAccess.Entities
{
    public class Place
    {
        [Key]
        public int Id { get; set; } // PK

        public string Name { get; set; } 

        public string Address { get; set; }

        public string ShortDicription { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }

        // Place - Place Detail
        public PlaceDetail PlaceDetail { get; set; }

        // Place - Booking
        public ICollection<Booking> Bookings { get; set; }


        // City - Place
        public int CityId { get; set; }
        public City City { get; set; }

        // PlaceType - Place
        public int PlaceTypeID { get; set; }
        public PlaceType PlaceType { get; set; }

        // User - Place
        public Guid UserId { get; set; }
        public User User { get; set; }

        // Place - Image
        public ICollection<PlaceImage> Images { get; set; }
    }
}
