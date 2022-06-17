using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Common;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Entities
{
    public class Booking : AuditableEntity
    {
        [Key]
        public int Id { get; set; } // PK
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public BookingStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Deposit { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
