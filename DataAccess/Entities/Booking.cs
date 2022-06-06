using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; } // PK


        public DateTime BookingFromTime { get; set; }


        public DateTime BookingToTime { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        public int Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal Deposit { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        // Place - Booking

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        // User - Booking
        public Guid CurrentUserId { get; set; }
        public User User { get; set; }

    }
}
