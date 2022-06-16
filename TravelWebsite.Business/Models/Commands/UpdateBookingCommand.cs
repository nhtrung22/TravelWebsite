namespace TravelWebsite.Business.Models.Commands
{
    public class UpdateBookingCommand
    {
        public int Id { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public decimal Deposit { get; set; }
    }
}
