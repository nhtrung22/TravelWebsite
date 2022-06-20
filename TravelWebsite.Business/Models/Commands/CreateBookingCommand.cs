namespace TravelWebsite.Business.Models.Commands
{
    public class CreateBookingCommand
    {
        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public decimal Price { get; set; }

        public int PropertyId { get; set; }

        public decimal Deposit { get; set; }
    }
}
