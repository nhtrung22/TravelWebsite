using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.Business.Models.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public decimal Price { get; set; }

        public PropertyDTO Property { get; set; } = default!;

        public UserDTO User { get; set; } = default!;

        public BookingStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public decimal Deposit { get; set; }

    }
}
