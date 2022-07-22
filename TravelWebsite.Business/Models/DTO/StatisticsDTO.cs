namespace TravelWebsite.Business.Models.DTO
{
    public class StatisticsDTO
    {
        public int NumberOfUsers { get; set; }
        public int NumberOfOrders { get; set; }
        public decimal Earnings { get; set; }
        public IEnumerable<BookingDTO> LatestTransactions { get; set; } = default!;
    }
}
