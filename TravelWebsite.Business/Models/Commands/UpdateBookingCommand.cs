namespace TravelWebsite.Business.Models.Commands
{
    public class UpdateBookingCommand
    {
        public int Id { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfKids { get; set; }

        public decimal Deposit { get; set; }
    }
}
