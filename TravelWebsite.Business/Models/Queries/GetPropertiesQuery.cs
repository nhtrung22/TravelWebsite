namespace TravelWebsite.Business.Models.Queries
{
    public class GetPlacesQuery
    {
        public string City { get; set; } = "";
        public int NumberOfAdults { get; set; } = 0;
        public int NumberOfKids { get; set; } = 1;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
