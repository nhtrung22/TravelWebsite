namespace TravelWebsite.Business.Models.Queries
{
    public class GetPlacesQuery : PaginatedList
    {
        public string City { get; set; }
    }
}
