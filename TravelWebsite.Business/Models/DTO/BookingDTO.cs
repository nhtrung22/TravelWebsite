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

        public int PlaceId { get; set; }

        public DateTime Date { get; set; }

        public BookingStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal Deposit { get; set; }

    }
}
