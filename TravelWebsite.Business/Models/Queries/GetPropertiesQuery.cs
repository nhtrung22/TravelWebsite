namespace TravelWebsite.Business.Models.Queries
{
    public class GetPropertiesQuery
    {
        public string? City { get; set; } = "";
        public int NumberOfAdults { get; set; } = 0;
        public int NumberOfKids { get; set; } = 0;
        public int NumberOfRooms { get; set; } = 0;
        public int MaxPrice { get; set; } = 0;
        public int MinPrice { get; set; } = 0;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
