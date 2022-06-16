using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; } // PK

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public decimal Price { get; set; }

        public BookingStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal Deposit { get; set; }

        // Place - Booking

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        // User - Booking
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
